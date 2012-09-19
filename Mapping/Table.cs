using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Stump.ORM.Mapping.Attributes;
using Stump.ORM.Sql;

namespace Stump.ORM.Mapping
{
    public class Table
    {
        private string m_createTableQuery;
        private string m_createEntityQuery;
        private string m_selectEntityQuery;
        private string m_updateEntityQuery;
        private List<Column> m_columns = new List<Column>();

        public Table(TableAttribute attribute, Type type)
        {
            Attribute = attribute;
            Type = type;
        }

        public void Initialize()
        {
            LoadColumns();
            CreateQueries();
        }

        private void LoadColumns()
        {
            foreach (var field in Type.GetFields())
            {
                var attrs = field.GetCustomAttributes(typeof(FieldAttribute), false);

                if (attrs.Any())
                {
                    m_columns.Add(new Column(this, field));
                }
            } 
            
            foreach (var property in Type.GetProperties())
            {
                var attrs = property.GetCustomAttributes(typeof(FieldAttribute), false);

                if (attrs.Any())
                {
                    m_columns.Add(new Column(this, property));
                }
            }
        }

        private void CreateQueries()
        {
            var selectBuilder = new SqlSelectBuilder();
            selectBuilder.AddSourceTable(this);

            foreach (Column column in Columns)
            {
                selectBuilder.AddSelectResult(column);
            }

            m_selectEntityQuery = selectBuilder.ToString();


            var updateBuilder = new SqlUpdateBuilder();
            updateBuilder.AddUpdateTable(this);

            foreach (Column column in Columns)
            {
                updateBuilder.AddSet(column);
            }

            m_selectEntityQuery = updateBuilder.ToString();


            var insertBuilder = new SqlInsertBuilder();
            insertBuilder.SetInsertTable(this);

            foreach (Column column in Columns)
            {
                insertBuilder.AddSet(column);
            }

            m_selectEntityQuery = insertBuilder.ToString();

            var createBuilder = new SqlCreateTableBuilder();

            createBuilder.SetTable(this);

            foreach (Column column in Columns)
            {
                createBuilder.AddColumn(column);
            }

            m_createTableQuery = createBuilder.ToString();
        }

        public string Name
        {
            get { return Attribute.Name; }
        }

        public TableAttribute Attribute
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            set;
        }

        public ReadOnlyCollection<Column> Columns
        {
            get { return m_columns.AsReadOnly(); }
        }

        public string Engine
        {
            get;
            set;
        }

        public int AutoIncrement
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public DateTime UpdateTime
        {
            get;
            set;
        }
    }
}