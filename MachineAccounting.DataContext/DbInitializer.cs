using System.Linq;
using MachineAccounting.DataContext.Models;

namespace MachineAccounting.DataContext
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Storages.Any())
            {
                return; // DB has been seeded
            }


            var storages = new[]
            {
                new Storage {Adress = "ул. Тестовая, д.1 офис 1", Name = "Склад 1"},
                new Storage {Adress = "ул. Тестовая, д.2 офис 2", Name = "Склад 2"}
            };
            foreach (Storage s in storages)
            {
                context.Storages.Add(s);
            }

            context.SaveChanges();

            var sections = new[]
            {
                new Section
                {
                    Name = "ДОРОЖНАЯ ТЕХНИКА SANY",
                    Description =
                        " Бетононасосы, автобетононасосы SANY Heavy Industry Co. Ltd. Beijing China / 三一 Sany Group Co. Ltd. Китай, Буровые установки, Гусеничный кран, Автокран, Ричстакер, Экскаватор, Сваебойная установка"
                },
                new Section
                {
                    Name = "АДРЕСНАЯ ПОДАЧА БЕТОНА",
                    Description =
                        " Бетононасосы, автобетононасосы SANY Heavy Industry Co. Ltd. Beijing China / 三一 Sany Group Co. Ltd. Китай, Буровые установки, Гусеничный кран, Автокран, Ричстакер, Экскаватор, Сваебойная установка"
                }
            };
            foreach (Section s in sections)
            {
                context.Sections.Add(s);
            }

            var machineTypes = new[]
            {
                new MachineType { Name = "АВТОМОБИЛЬНЫЕ И Ж/Д ВЕСЫ"},
                new MachineType {Name = "АСФАЛЬТОУКЛАДЧИКИ", Section = sections[0]},
                new MachineType {Name = "ДОРОЖНЫЕ КАТКИ", Section = sections[0]},
                new MachineType {Name = "ФРЕЗЕРНЫЕ МАШИНЫ", Section = sections[0]},
                new MachineType {Name = "ЭКСКАВАТОРЫ", Section = sections[0]},
                new MachineType {Name = "ПОГРУЗЧИК", Section = sections[0]},
                new MachineType {Name = "КЮБЕЛИ АДРЕСНОЙ ПОДАЧИ БЕТОНА (РОССИЯ)", Section = sections[1]},
                new MachineType {Name = "КЮБЕЛИ АДРЕСНОЙ ПОДАЧИ БЕТОНА (ИТАЛИЯ)", Section = sections[1]},
                new MachineType {Name = "ТЕЛЕЖКИ ДЛЯ ПЕРЕВОЗКИ БЕТОНА", Section = sections[1]},
                new MachineType {Name = "БЕТОНОРАЗДАТЧИКИ", Section = sections[1]}
            };
            foreach (MachineType s in machineTypes)
            {
                context.MachineTypes.Add(s);
            }

            var machines = new[]
            {
                new Machine
                {
                    MachineType = machineTypes[1],
                    Name = "МНОГОФУНКЦИОНАЛЬНЫЕ АСФАЛЬТОУКЛАДЧИКИ SANY SMP",
                    Price = 256000,
                    Currency = "EUR",
                    Rest = 25,
                    Storage = storages[0]
                },
                new Machine
                {
                    MachineType = machineTypes[1],
                    Name = "АСФАЛЬТОУКЛАДЧИКИ СЕРИИ SAP",
                    Price = 183000,
                    Currency = "$",
                    Rest = 15,
                    Storage = storages[0]
                },
                new Machine
                {
                    MachineType = machineTypes[1],
                    Name = "АСФАЛЬТОУКЛАДЧИК ДЛЯ УПЛОТНЕННОГО ГРУНТА СЕРИЯ SSP",
                    Price = 296000,
                    Currency = "$",
                    Rest = 2,
                    Storage = storages[0]
                },
                new Machine
                {
                    MachineType = machineTypes[2],
                    Name = "ПНЕВМАТИЧЕСКИЕ ДОРОЖНЫЕ КАТКИ SANY СЕРИИ SPR",
                    Price = 86000,
                    Currency = "$",
                    Rest = 22,
                    Storage = storages[0]
                },
                new Machine
                {
                    MachineType = machineTypes[2],
                    Name = "ДВУХВАЛЬЦОВЫЕ ДОРОЖНЫЕ КАТКИ SANY СЕРИИ STR",
                    Price = 97500,
                    Currency = "$",
                    Rest = 12,
                    Storage = storages[0]
                },
                new Machine
                {
                    MachineType = machineTypes[2],
                    Name = "ОДНОВАЛЬЦОВЫЕ ДОРОЖНЫЕ КАТКИ SANY СЕРИИ SSR",
                    Price = 75900,
                    Currency = "$",
                    Rest = 1,
                    Storage = storages[0]
                }
            };

            foreach (Machine s in machines)
            {
                context.Machines.Add(s);
            }

            context.SaveChanges();
        }
    }
}