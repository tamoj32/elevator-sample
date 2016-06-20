using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Elevator.Domain.Entities;
using Elevator.Domain.Interfaces;
using Elevator.Infrastructure.Data.Mapping;
using Elevator.Infrastructure.Interfaces;

namespace Elevator.Infrastructure.Data.Repositories
{
    public class ElevatorRepository : IElevatorRepository
    {
        private readonly ILoggingService _loggingService;

        public ElevatorRepository(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        /// Get All Elevator as Iquerable
        /// </summary>
        /// <returns></returns>
        public IQueryable<Domain.Entities.Elevator> All()
        {
            using (var context = new ElevatorContext())
            {
                var elevators = context.Elevators;

                // Log call
                _loggingService.Info("Elevator.Infrastructure.Data.Repositories: ElevatorRepository.All");

                return elevators;

            }
        }

        /// <summary>
        /// Get All Elevator as List
        /// </summary>
        /// <returns></returns>
        public List<Domain.Entities.Elevator> AllList()
        {
            using (var context = new ElevatorContext())
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var elevators = context.Elevators.ToList();
                stopWatch.Stop();
                // Log call
                _loggingService.Info("Elevator.Infrastructure.Data.Repositories: ElevatorRepository.AllList, Elapsed (ms): " + stopWatch.ElapsedMilliseconds);

                return elevators;

            }

        }

        /// <summary>
        /// Get All Elevator with search func expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Domain.Entities.Elevator> AllList(Expression<Func<Domain.Entities.Elevator, bool>> expression)
        {
            using (var context = new ElevatorContext())
            {
                var elevators = context.Elevators.Where(expression).ToList();

                // Log call
                _loggingService.Info("Elevator.Infrastructure.Data.Repositories: ElevatorRepository.AllList expression");
                return elevators;

            }
            
        }

        /// <summary>
        /// Get Elevator by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Domain.Entities.Elevator Get(int id)
        {
            using (var context = new ElevatorContext())
            {
                var elevator = context.Elevators.Find(id);

                //log call
                _loggingService.Info("Elevator.Infrastructure.Data.Repositories: ElevatorRepository.Get");

                return elevator;

            }

        }

        /// <summary>
        /// Update current Elevator to db
        /// </summary>
        /// <param name="elevator"></param>
        /// <returns></returns>
        public bool Update(Domain.Entities.Elevator elevator)
        {
            using (var context = new ElevatorContext())
            {
                context.Elevators.Attach(elevator);

                var entry = context.Entry(elevator);
                entry.State = EntityState.Modified;
                context.SaveChanges();

                //log call
                _loggingService.Info("Elevator.Infrastructure.Data.Repositories: ElevatorRepository.Update");
                return true;

            }
        }
    }

}
