using AppPermission.Domain.DTO;
using AppPermission.Domain.Entities;
using AppPermission.Domain.Interface;
using AppPermission.Infrastructure.Context;
using AppPermission.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppPermission.UnitTest.Infrastruture
{
    public class PermissionRepositoryTest
    {
        private readonly AppPermissionContext _context = null;
        private readonly IPermissionRepository _repository;

        public PermissionRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<AppPermissionContext>()
                .UseInMemoryDatabase("dbPermission")
                .Options;

            _context = new AppPermissionContext(options);

            _repository = new PermissionRepository(_context);

            Permission permissions = new Permission()
            {
                FirstName = "Enyher",
                LastName = "Jimenez",
                PermissionType = 3,
                PermissionDate = DateTime.Now
            };

            _repository.Save(permissions);
        }
        [Fact]
        public void GetPermission_WithValidPermissionDTO()
        {
            //Arrange
            var permissions = _repository.GetPermission();

            //Expect

            //Assert
            Assert.NotNull(permissions);
            Assert.IsType<List<PermissionDTO>>(permissions);
        }
    }
}
