using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Business.Data
{
    public class SpecificationEvaluator<T> where T: ModelBase
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            //logics
            if(specification.Criteria != null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }

            //includes [ Entities ]
            inputQuery = specification
                .Includes
                .Aggregate(inputQuery, (current, include)=>
                {
                    return current.Include(include);
                });

            // IQueryable
            return inputQuery;
        }
    }
}
