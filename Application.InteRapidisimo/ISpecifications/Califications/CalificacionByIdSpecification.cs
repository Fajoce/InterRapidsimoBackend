using Domain.IterRapisimo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.ISpecifications.Califications
{
    public class CalificacionByIdSpecification : ISpecification<Calificacion>
    {
        private readonly int _calificacionId;

        public CalificacionByIdSpecification(int calificacionId)
        {
            _calificacionId = calificacionId;
        }

        public Expression<Func<Calificacion, bool>> ToExpression()
        {
            return c => c.CalificacionID == _calificacionId;
        }
    }
}
