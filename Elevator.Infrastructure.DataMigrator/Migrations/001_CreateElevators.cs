using System.Data;
using ECM7.Migrator.Framework;

namespace Elevator.Infrastructure.DataMigrator.Migrations
{
    [Migration(001)]
    public class _001_CreateElevators : Migration
    {
        private const string TABLE = "Elevators";

        public override void Apply()
        {
            Database.AddTable(TABLE, new[]
            {
                new Column("ElevatorId", DbType.Int32, ColumnProperty.PrimaryKey), 
                new Column("Name", DbType.String, ColumnProperty.NotNull), 
                new Column("CurrentFloor", DbType.Int16, ColumnProperty.NotNull),
                new Column("Direction", DbType.Int16, ColumnProperty.NotNull, 0),
                new Column("TotalPeople", DbType.Int16, ColumnProperty.NotNull, 0)
            });
        }

        public override void Revert()
        {
            Database.RemoveTable(TABLE);
        }
    }
}