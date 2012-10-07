﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Stump.ORM.SubSonic.DataProviders;
using Stump.ORM.SubSonic.Extensions;
using Stump.ORM.SubSonic.Schema;

namespace Stump.ORM
{
    public class DatabaseAccessor
    {
        private class MappingEntry
        {
            public MappingEntry()
            {
            }

            public MappingEntry(Type type, ITable table)
            {
                Type = type;
                Table = table;
            }

            public MappingEntry(Type type)
            {
                Type = type;
            }

            public Type Type
            {
                get;
                set;
            }

            public ITable Table
            {
                get;
                set;
            }
        }

        private List<MappingEntry> m_mapping = new List<MappingEntry>();
        private List<Assembly> m_assemblies = new List<Assembly>();

        public DatabaseAccessor(DatabaseConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DatabaseConfiguration Configuration
        {
            get;
            set;
        }

        public IDataProvider DataProvider
        {
            get;
            private set;
        }

        public Database Database
        {
            get;
            private set;
        }

        public void RegisterMappingAssembly(Assembly assembly)
        {
            m_assemblies.Add(assembly);
        }

        public void Initialize()
        {
            foreach (var assembly in m_assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetInterface(typeof(IAutoGeneratedRecord).FullName) != null ||
                        type.GetInterface(typeof(IManualGeneratedRecord).FullName) != null)
                    {
                        m_mapping.Add(new MappingEntry(type));
                    }
                }
            }
        }

        public void OpenConnection()
        {
            DataProvider = ProviderFactory.GetProvider(Configuration.GetConnectionString(), Configuration.ProviderName);
            Database = new Database(Configuration.GetConnectionString(), Configuration.ProviderName);

            Database.OpenSharedConnection();

            foreach (var map in m_mapping)
            {
                if (map.Table != null)
                    continue;

                ITable table;
                if (map.Type.GetInterface(typeof (IManualGeneratedRecord).FullName) != null)
                {
                    var instance = Activator.CreateInstance(map.Type, true);
                    table = ((IManualGeneratedRecord)instance).GetTableInformation();
                }
                else
                {
                    table = map.Type.ToSchemaTable(DataProvider);
                }

                map.Table = table;

                var query = map.Table.CreateSql;

                Database.Execute(query);
            }
        }

        public void CloseConnection()
        {
            Database.CloseSharedConnection();
        }
    }
}