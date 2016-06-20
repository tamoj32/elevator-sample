using System.Data;
using ECM7.Migrator.Framework;
using ForeignKeyConstraint = ECM7.Migrator.Framework.ForeignKeyConstraint;

namespace Elevator.Infrastructure.DataMigrator.Migrations
{
    [Migration(002)]
    public class _002_CreateFloors : Migration
    {
        private const string TABLE = "Floors";

        public override void Apply()
        {
            Database.AddTable(TABLE, new[]
            {
                new Column("CurrentFloor", DbType.Int16, ColumnProperty.PrimaryKey), 
                new Column("DestinationFloor", DbType.Int16, ColumnProperty.NotNull), 
                new Column("TotalPeople", DbType.Int16, ColumnProperty.NotNull, 0),
            });
        }

        public override void Revert()
        {
            Database.RemoveTable(TABLE);
        }
    }
}