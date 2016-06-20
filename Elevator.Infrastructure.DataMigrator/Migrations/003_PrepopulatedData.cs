using System.Data;
using ECM7.Migrator.Framework;
using ForeignKeyConstraint = ECM7.Migrator.Framework.ForeignKeyConstraint;

namespace Elevator.Infrastructure.DataMigrator.Migrations
{
    [Migration(003)]
    public class _003_PrepopulatedData : Migration
    {

        public override void Apply()
        {
            //Insert Make
            Database.Insert("Elevators", new string[] {"ElevatorId", "Name", "CurrentFloor", "Direction", "TotalPeople" }, new string[] { "1","Elevator A", "1", "0", "0" });
            Database.Insert("Elevators", new string[] { "ElevatorId", "Name", "CurrentFloor", "Direction", "TotalPeople" }, new string[] { "2","Elevator B", "1", "0", "0" });
            Database.Insert("Elevators", new string[] { "ElevatorId", "Name", "CurrentFloor", "Direction", "TotalPeople" }, new string[] { "3","Elevator C", "1", "0", "0" });
            Database.Insert("Elevators", new string[] { "ElevatorId", "Name", "CurrentFloor", "Direction", "TotalPeople" }, new string[] { "4","Elevator D", "1", "0", "0" });

            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "1", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "2", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "3", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "4", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "5", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "6", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "7", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "8", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "9", "1", "0" });
            Database.Insert("Floors", new string[] { "CurrentFloor", "DestinationFloor", "TotalPeople" }, new string[] { "10", "1", "0" });            

        }

        public override void Revert()
        {
            Database.Delete("Elevators");
            Database.Delete("Floors");
        }
    }
}