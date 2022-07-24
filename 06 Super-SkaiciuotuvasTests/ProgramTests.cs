using Microsoft.VisualStudio.TestTools.UnitTesting;
using _06_Super_Skaiciuotuvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//_06_Super_Skaiciuotuvas.Tests

namespace _06_Super_Skaiciuotuvas.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void SuperSkaiciuotuvasTest1()
        {
            var fake_moves = new string[] { "1", "1", "15", "45", "2", "2", "10", "3" };
            var expected = 50d;

            Program.Reset();
            foreach (var move in fake_moves)
            {
                Program.SuperSkaiciuotuvas(move);
            }
            var actual = _06_Super_Skaiciuotuvas.Program.Rezultatas();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SuperSkaiciuotuvasTest2()
        {
            var fake_moves = new string[] { "1", "1", "15", "45", "3" };
            var expected = 60d;
            _06_Super_Skaiciuotuvas.Program.Reset();
            foreach (var move in fake_moves)
            {
                _06_Super_Skaiciuotuvas.Program.SuperSkaiciuotuvas(move);
            }
            var actual = _06_Super_Skaiciuotuvas.Program.Rezultatas();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SuperSkaiciuotuvasTest3()
        {
            var fake_moves = new string[] { "1", "1", "15", "45", "2", "2", "10", "1", "3", "2", "3", "3" };
            var expected = 6d;

            _06_Super_Skaiciuotuvas.Program.Reset();
            foreach (var move in fake_moves)
            {
                _06_Super_Skaiciuotuvas.Program.SuperSkaiciuotuvas(move);
            }
            var actual = _06_Super_Skaiciuotuvas.Program.Rezultatas();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MoveCountReturnTest()
        {
            //var fake_moves = new string[] { "1", "1", "15", "45", "3" };
            var expected = 0;
            _06_Super_Skaiciuotuvas.Program.Reset();
            var actual = _06_Super_Skaiciuotuvas.Program.MoveCountReturn();

            Assert.AreEqual(expected, actual);
        }
    }
}