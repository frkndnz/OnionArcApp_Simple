using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Interfaces.Repository
{
    public interface IProductRepository:IGenericRepositoryAsync<Product>
    {
       
    }
}
