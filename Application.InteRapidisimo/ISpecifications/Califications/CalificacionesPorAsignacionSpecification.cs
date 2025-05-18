using Domain.IterRapisimo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.InteRapidisimo.ISpecifications.Califications
{
    public class CalificacionesPorAsignacionSpecification : ISpecification<Calificacion>
    {
        private readonly int _asignacionId;

        public CalificacionesPorAsignacionSpecification(int asignacionId)
        {
            _asignacionId = asignacionId;
        }

        public Expression<Func<Calificacion, bool>> ToExpression()
        {
            return c => c.AsignacionID == _asignacionId;
        }
    }
}
