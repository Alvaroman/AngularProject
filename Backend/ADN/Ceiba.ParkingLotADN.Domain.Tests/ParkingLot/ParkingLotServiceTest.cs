using Ceiba.ParkingLotADN.Domain.Exception;
using Ceiba.ParkingLotADN.Domain.Ports;
using Ceiba.ParkingLotADN.Domain.Services;
using Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState;
using Ceiba.ParkingLotADN.Domain.Services.ParkingPicoPlacaState;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ceiba.ParkingLotADN.Domain.Tests.ParkingLot
{
    [TestClass]
    public class ParkingLotServiceTest
    {
        IGenericRepository<Ceiba.ParkingLotADN.Domain.Entities.ParkingLot> _parkingLotRepository = default!;
        ParkingLotService _parkingLotService = default!;
        ChargerContext _chargerContext = default!;
        PicoPlacaContext _picoPlacaContext = default!;
        [TestInitialize]
        public void Init()
        {
            _parkingLotRepository = Substitute.For<IGenericRepository<Ceiba.ParkingLotADN.Domain.Entities.ParkingLot>>();
            _chargerContext = Substitute.For<ChargerContext>();
            _picoPlacaContext = Substitute.For<PicoPlacaContext>();
            _parkingLotService = new ParkingLotService(_parkingLotRepository, _chargerContext, _picoPlacaContext);
        }

        [TestMethod]
        public async Task FailToRegisterAnNotAllowedVehicleAsync()
        {
            try
            {
                Ceiba.ParkingLotADN.Domain.Entities.ParkingLot notAllowedVehicle = new ParkingLotDataBuilder()
                 .WithCylinder(0)
                 .WithVehicleType(3)
                 .WithStartAt(System.DateTime.Now)
                 .WithPlate("abc-123")
                 .WithStaus(false).Build();
                await _parkingLotService.RegisterParkingLotAsync(notAllowedVehicle);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is VehicleNotAllowedException);
            }
        }
        [TestMethod]
        public async Task FailToRegisterMotorcyclePicoPlacaAsync()
        {
            try
            {
                Ceiba.ParkingLotADN.Domain.Entities.ParkingLot notAllowedByPicoPlaca = new ParkingLotDataBuilder()
                  .WithCylinder(450)
                  .WithVehicleType(2)
                  .WithStartAt(new System.DateTime(year: 2022, month: 03, day: 21))
                  .WithPlate("abc-623")
                  .WithStaus(false).Build();
                await _parkingLotService.RegisterParkingLotAsync(notAllowedByPicoPlaca);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is PicoPlacaExceptionException);
            }
        }
        [TestMethod]
        public async Task FailToRegisterCarPicoPlacaAsync()
        {
            try
            {
                Ceiba.ParkingLotADN.Domain.Entities.ParkingLot parkingLotNowAllowed = new ParkingLotDataBuilder()
                  .WithCylinder(1800)
                  .WithVehicleType(1)
                  .WithStartAt(new System.DateTime(year: 2022, month: 03, day: 21))
                  .WithPlate("abc-126")
                  .WithStaus(false).Build();
                await _parkingLotService.RegisterParkingLotAsync(parkingLotNowAllowed);
            }
            catch (System.Exception ex)
            {
                Assert.IsTrue(ex is PicoPlacaExceptionException);
            }
        }
        [TestMethod]
        public async Task SuccessToRegisterParkingLotAsync()
        {
            Ceiba.ParkingLotADN.Domain.Entities.ParkingLot parkingLot = new ParkingLotDataBuilder()
                    .WithCylinder(1600)
                    .WithVehicleType(1)
                    .WithStartAt(new System.DateTime(year: 2022, month: 03, day: 20))
                    .WithPlate("abc-123")
                    .WithStaus(false).Build();

            _parkingLotRepository.AddAsync(Arg.Any<Ceiba.ParkingLotADN.Domain.Entities.ParkingLot>()).Returns(Task.FromResult(parkingLot));

            var result = await _parkingLotService.RegisterParkingLotAsync(parkingLot);

            Assert.IsTrue(result is Ceiba.ParkingLotADN.Domain.Entities.ParkingLot && result?.Id is not null);
        }
        [TestMethod]
        public void SuccessToObtainCostCar()
        {
            var cost = _chargerContext.CalculateCharge(27, 1800, Enums.VehicleType.Car);
            Assert.IsTrue(11000 == cost);
        }
        [TestMethod]
        public void SuccessToObtainCostMotorcycle()
        {
            var cost = _chargerContext.CalculateCharge(10, 650, Enums.VehicleType.Motorcycle);
            Assert.IsTrue(6000 == cost);
        }
        [TestMethod]
        public async Task FailToObtainParkingLotVehicleAsync()
        {
            var parkingLotNull = await _parkingLotRepository.GetByIdAsync("-1");
            Assert.IsTrue(parkingLotNull is null);
        }
        [TestMethod]
        public async Task FailToObtainParkingLotVehicleListAsync()
        {
            var parkingLotListNull = await _parkingLotRepository.GetAsync(x => x.VehicleType == -1);
            Assert.IsTrue(!parkingLotListNull.Any());
        }
    }
}
