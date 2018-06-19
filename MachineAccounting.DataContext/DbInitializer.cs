using System;
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
                new Storage {Adress = "ул. Тестовая, д.1 офис 1", Id = 1, Name = "Склад 1"},
                new Storage {Adress = "ул. Тестовая, д.2 офис 2", Id = 2, Name = "Склад 2"}
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
                    Id = 1,
                    Description = " Бетононасосы, автобетононасосы SANY Heavy Industry Co. Ltd. Beijing China / 三一 Sany Group Co. Ltd. Китай, Буровые установки, Гусеничный кран, Автокран, Ричстакер, Экскаватор, Сваебойная установка"
                },
                new Section
                {
                    Name = "АДРЕСНАЯ ПОДАЧА БЕТОНА",
                    Id = 2,
                    Description = " Бетононасосы, автобетононасосы SANY Heavy Industry Co. Ltd. Beijing China / 三一 Sany Group Co. Ltd. Китай, Буровые установки, Гусеничный кран, Автокран, Ричстакер, Экскаватор, Сваебойная установка"
                }
            };
            foreach (Section s in sections)
            {
                context.Sections.Add(s);
            }

            var machineTypes = new[]
            {
                new MachineType {Id = 1, Name = "АВТОМОБИЛЬНЫЕ И Ж/Д ВЕСЫ"},
                new MachineType {Name = "АСФАЛЬТОУКЛАДЧИКИ", Id = 2, SectionId = 1},
                new MachineType {Name = "ДОРОЖНЫЕ КАТКИ", Id = 3, SectionId = 1},
                new MachineType {Name = "ФРЕЗЕРНЫЕ МАШИНЫ", Id = 4, SectionId = 1},
                new MachineType {Name = "ЭКСКАВАТОРЫ", Id = 5, SectionId = 1},
                new MachineType {Name = "ПОГРУЗЧИК", Id = 6, SectionId = 1},
                new MachineType {Name = "КЮБЕЛИ АДРЕСНОЙ ПОДАЧИ БЕТОНА (РОССИЯ)", Id = 7, SectionId = 2},
                new MachineType {Name = "КЮБЕЛИ АДРЕСНОЙ ПОДАЧИ БЕТОНА (ИТАЛИЯ)", Id = 8, SectionId = 2},
                new MachineType {Name = "ТЕЛЕЖКИ ДЛЯ ПЕРЕВОЗКИ БЕТОНА", Id = 9, SectionId = 2},
                new MachineType {Name = "БЕТОНОРАЗДАТЧИКИ", Id = 10, SectionId = 2}
            };
            foreach (MachineType s in machineTypes)
            {
                context.MachineTypes.Add(s);
            }

            var machines = new[]
            {
                new Machine
                {
                    Id = 1,
                    MachineTypeId = 2,
                    Name = "МНОГОФУНКЦИОНАЛЬНЫЕ АСФАЛЬТОУКЛАДЧИКИ SANY SMP",
                    Price = 256000,
                    Currency = "EUR",
                    Rest = 25,
                    StorageId = 1
                },
                new Machine
                {
                    Id = 2,
                    MachineTypeId = 2,
                    Name = "АСФАЛЬТОУКЛАДЧИКИ СЕРИИ SAP",
                    Price = 183000,
                    Currency = "$",
                    Rest = 15,
                    StorageId = 1
                },
                new Machine
                {
                    Id = 3,
                    MachineTypeId = 2,
                    Name = "АСФАЛЬТОУКЛАДЧИК ДЛЯ УПЛОТНЕННОГО ГРУНТА СЕРИЯ SSP",
                    Price = 296000,
                    Currency = "$",
                    Rest = 2,
                    StorageId = 1
                },
                new Machine
                {
                    Id = 4,
                    MachineTypeId = 3,
                    Name = "ПНЕВМАТИЧЕСКИЕ ДОРОЖНЫЕ КАТКИ SANY СЕРИИ SPR",
                    Price = 86000,
                    Currency = "$",
                    Rest = 22,
                    StorageId = 1
                },
                new Machine
                {
                    Id = 5,
                    MachineTypeId = 3,
                    Name = "ДВУХВАЛЬЦОВЫЕ ДОРОЖНЫЕ КАТКИ SANY СЕРИИ STR",
                    Price = 97500,
                    Currency = "$",
                    Rest = 12,
                    StorageId = 2
                },
                new Machine
                {
                    Id = 6,
                    MachineTypeId = 3,
                    Name = "ОДНОВАЛЬЦОВЫЕ ДОРОЖНЫЕ КАТКИ SANY СЕРИИ SSR",
                    Price = 75900,
                    Currency = "$",
                    Rest = 1,
                    StorageId = 2
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