using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using DataModels;
using EddnSubscriber;
using EddnSubscriber.Mappers;
using EddnSubscriber.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EddnSubscriberTests
{
    public class EddnToEdsmCelestialBodyTests
    {
        private readonly IFixture _fixture;
        private readonly IMapper _mapper;
        private readonly IDataReader _dataReader;

        public EddnToEdsmCelestialBodyTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _dataReader = _fixture.Create<DefaultDataReader>();
            _fixture.Register<IConfigurationProvider>(() => new MapperConfiguration(cfg => {
                cfg.CreateMap<EddnCelestialBody, CelestialBody>().ConvertUsing(_fixture.Create<EddnToEdsmCelestialBody>());
                cfg.CreateMap<EddnCelestialBodyRing, CelestialBodyRing>().ConvertUsing(_fixture.Create<EddnToEdsmRing>());
                cfg.CreateMap<EddnCelestialBodyRing, CelestialBodyBelt>().ConvertUsing(_fixture.Create<EddnToEdsmBelt>());
            }));
            _fixture.Register<IMapper>(() => new Mapper(_fixture.Create<IConfigurationProvider>()));
            _mapper = _fixture.Create<IMapper>();
        }

        [Fact]
        public void Map_Return_Rings()
        {
            var entity = _dataReader.Read<Entity<EddnCelestialBody>>(@"{
                ""$schemaRef"": ""https://eddn.edcd.io/schemas/journal/1"",
                ""header"": {
                    ""gatewayTimestamp"": ""2020-03-01T11:10:11.162476Z"",
                    ""softwareName"": ""E:D Market Connector [Windows]"",
                    ""softwareVersion"": ""3.4.3.0"",
                    ""uploaderID"": ""b43c99fb9a5fd12d041f16d2b1fdc704d8e155c3""
                },
                ""message"": {
                    ""Atmosphere"": """",
                    ""AtmosphereComposition"": [
                        {
                            ""Name"": ""Hydrogen"",
                            ""Percent"": 74.048958
                        },
                        {
                            ""Name"": ""Helium"",
                            ""Percent"": 25.951048
                        }
                    ],
                    ""AxialTilt"": 2.453876,
                    ""BodyID"": 11,
                    ""BodyName"": ""Pegasi Sector BV-Y c14 4"",
                    ""DistanceFromArrivalLS"": 1347.459229,
                    ""Eccentricity"": 0.000829,
                    ""Landable"": false,
                    ""MassEM"": 2646.929688,
                    ""OrbitalInclination"": 0.003067,
                    ""OrbitalPeriod"": 179692400.0,
                    ""Parents"": [
                        {
                            ""Star"": 0
                        }
                    ],
                    ""Periapsis"": 11.657269,
                    ""PlanetClass"": ""Sudarsky class III gas giant"",
                    ""Radius"": 70406312.0,
                    ""ReserveLevel"": ""PristineResources"",
                    ""Rings"": [
                        {
                            ""InnerRad"": 116170000.0,
                            ""MassMT"": 186910000000.0,
                            ""Name"": ""Pegasi Sector BV-Y c14 4 A Ring"",
                            ""OuterRad"": 144140000.0,
                            ""RingClass"": ""eRingClass_MetalRich""
                        },
                        {
                            ""InnerRad"": 144240000.0,
                            ""MassMT"": 6182000000000.0,
                            ""Name"": ""Pegasi Sector BV-Y c14 4 B Ring"",
                            ""OuterRad"": 495490000.0,
                            ""RingClass"": ""eRingClass_MetalRich""
                        },
                        {
                            ""InnerRad"": 45364356.0,
                            ""MassMT"": 35643456.0,
                            ""Name"": ""Pegasi Sector BV-Y c14 4 B Belt"",
                            ""OuterRad"": 345634563456456.0,
                            ""RingClass"": ""eRingClass_MetalRich""
                        }
                    ],
                    ""RotationPeriod"": 132869.296875,
                    ""ScanType"": ""Detailed"",
                    ""SemiMajorAxis"": 403641401344.0,
                    ""StarPos"": [
                        -153.375,
                        -82.59375,
                        -95.625
                    ],
                    ""StarSystem"": ""Pegasi Sector BV-Y c14"",
                    ""SurfaceGravity"": 212.827942,
                    ""SurfacePressure"": 0.0,
                    ""SurfaceTemperature"": 674.173889,
                    ""SystemAddress"": 3931874726594,
                    ""TerraformState"": """",
                    ""TidalLock"": false,
                    ""Volcanism"": """",
                    ""WasDiscovered"": true,
                    ""WasMapped"": true,
                    ""event"": ""Scan"",
                    ""timestamp"": ""2020-03-01T11:10:09Z""
                }
            }");
            var result = _mapper.Map<CelestialBody>(entity.Message);
            Assert.Equal(2, result.Rings.Count);
        }

        [Fact]
        public void Map_Return_Belts()
        {
            var entity = _dataReader.Read<Entity<EddnCelestialBody>>(@"{
                ""$schemaRef"": ""https://eddn.edcd.io/schemas/journal/1"",
                ""header"": {
                    ""gatewayTimestamp"": ""2020-03-01T11:10:11.162476Z"",
                    ""softwareName"": ""E:D Market Connector [Windows]"",
                    ""softwareVersion"": ""3.4.3.0"",
                    ""uploaderID"": ""b43c99fb9a5fd12d041f16d2b1fdc704d8e155c3""
                },
                ""message"": {
                    ""Atmosphere"": """",
                    ""AtmosphereComposition"": [
                        {
                            ""Name"": ""Hydrogen"",
                            ""Percent"": 74.048958
                        },
                        {
                            ""Name"": ""Helium"",
                            ""Percent"": 25.951048
                        }
                    ],
                    ""AxialTilt"": 2.453876,
                    ""BodyID"": 11,
                    ""BodyName"": ""Pegasi Sector BV-Y c14 4"",
                    ""DistanceFromArrivalLS"": 1347.459229,
                    ""Eccentricity"": 0.000829,
                    ""Landable"": false,
                    ""MassEM"": 2646.929688,
                    ""OrbitalInclination"": 0.003067,
                    ""OrbitalPeriod"": 179692400.0,
                    ""Parents"": [
                        {
                            ""Star"": 0
                        }
                    ],
                    ""Periapsis"": 11.657269,
                    ""PlanetClass"": ""Sudarsky class III gas giant"",
                    ""Radius"": 70406312.0,
                    ""ReserveLevel"": ""PristineResources"",
                    ""Rings"": [
                        {
                            ""InnerRad"": 116170000.0,
                            ""MassMT"": 186910000000.0,
                            ""Name"": ""Pegasi Sector BV-Y c14 4 A Ring"",
                            ""OuterRad"": 144140000.0,
                            ""RingClass"": ""eRingClass_MetalRich""
                        },
                        {
                            ""InnerRad"": 144240000.0,
                            ""MassMT"": 6182000000000.0,
                            ""Name"": ""Pegasi Sector BV-Y c14 4 B Ring"",
                            ""OuterRad"": 495490000.0,
                            ""RingClass"": ""eRingClass_MetalRich""
                        },
                        {
                            ""InnerRad"": 45364356.0,
                            ""MassMT"": 35643456.0,
                            ""Name"": ""Pegasi Sector BV-Y c14 4 B Belt"",
                            ""OuterRad"": 345634563456456.0,
                            ""RingClass"": ""eRingClass_MetalRich""
                        }
                    ],
                    ""RotationPeriod"": 132869.296875,
                    ""ScanType"": ""Detailed"",
                    ""SemiMajorAxis"": 403641401344.0,
                    ""StarPos"": [
                        -153.375,
                        -82.59375,
                        -95.625
                    ],
                    ""StarSystem"": ""Pegasi Sector BV-Y c14"",
                    ""SurfaceGravity"": 212.827942,
                    ""SurfacePressure"": 0.0,
                    ""SurfaceTemperature"": 674.173889,
                    ""SystemAddress"": 3931874726594,
                    ""TerraformState"": """",
                    ""TidalLock"": false,
                    ""Volcanism"": """",
                    ""WasDiscovered"": true,
                    ""WasMapped"": true,
                    ""event"": ""Scan"",
                    ""timestamp"": ""2020-03-01T11:10:09Z""
                }
            }");
            var result = _mapper.Map<CelestialBody>(entity.Message);
            Assert.Equal(1, result.Belts.Count);
        }
    }
}
