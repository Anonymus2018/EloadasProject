using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EloadasProject.Tests
{
    [TestFixture]
    class EloadasTest
    {
        Eloadas eloadas;

        [SetUp]
        public void SetUp()
        {
            eloadas = new Eloadas(10, 10);
        }

        [TestCase]
        public void UjEloadasMindenHelySzabad()
        {
            Assert.AreEqual(100, eloadas.SzabadHelyek, "A szabad helyek száma hibás!");
        }

        [TestCase]
        public void HelyFoglalasUtanAHelyekSzamaCsokken()
        {
            eloadas.Lefoglal();
            Assert.AreEqual(99, eloadas.SzabadHelyek, "A szabad helyek nem csökkentek!");
        }

        [TestCase]
        public void EloadasNincsTeli()
        {
            Assert.IsFalse(eloadas.Teli(), "Üres előadás teli van!");
        }

        [TestCase]
        public void EloadasTeli()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    eloadas.Lefoglal();
                }
            }
            Assert.IsTrue(eloadas.Teli(), "Teli előadás mégsincs teli!");
        }

        [TestCase]
        public void TeliEloadasraNeLehessenFoglalni()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    eloadas.Lefoglal();
                }
            }
            bool sikerult = eloadas.Lefoglal();
            Assert.AreEqual(0, eloadas.SzabadHelyek);
            Assert.IsTrue(eloadas.Teli());
            Assert.IsFalse(sikerult);
        }

        [TestCase]
        public void SorokEsHelyekSzamaNemLehetNegativ()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var eloadas = new Eloadas(-2, -2);
            });
        }

        [TestCase]
        public void FoglaltNemLehetKisebbMintEgy()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.Foglalt(0, 0);
            });
        }

        [TestCase]
        public void FoglaltNemLehetNagyobbMintAmiVan()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                eloadas.Foglalt(11, 11);
            });
        }
    }
}
