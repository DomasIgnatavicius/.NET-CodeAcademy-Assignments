namespace _05_DNR_inzinerija_testai
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void grandinesNormalizavimoTestas()
        {
            bool arNormalizuota = false;
            var fake = " T CG-TAC- gaC-TAC-CGT-CAG-ACT-TAa-CcA-GTC-cAt-AGA-GCT    ";
            var expected = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var actual = _05_DNR_inzinerija.Program.grandinesNormalizavimas(fake, ref arNormalizuota);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void arGrandineValidiTest()
        {
            var fake = " T CG-TAC- gaC-TAC-CGT-CAG-ACT-TAa-CcA-GTC-cAt-AGA-GCT    ";
            var expected = true;
            var actual = _05_DNR_inzinerija.Program.arGrandineValidi(fake);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GCTtoAGGTest()
        {
            var fake = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var expected = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-AGG";
            var actual = _05_DNR_inzinerija.Program.GCTtoAGG(fake);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void arGrandinejeYraCAT()
        {
            var fake = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var expected = "Tekste yra CAT";
            var actual = _05_DNR_inzinerija.Program.arGrandinejeYraCAT(fake);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Gauti3ir5Segmentus()
        {
            var fake = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var expected = "GAC-CGT";
            var actual = _05_DNR_inzinerija.Program.Gauti3ir5Segmentus(fake);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void raidziuKiekisTexte()
        {
            var fake = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var expected = 39;
            var actual = _05_DNR_inzinerija.Program.raidziuKiekisTexte(fake);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void kiekKartuPasikartojaIvestasSegmentas()
        {
            var faketxt = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var fakesegmentas = "TAC";
            var expected = 2;
            var actual = _05_DNR_inzinerija.Program.kiekKartuPasikartojaIvestasSegmentas(faketxt, fakesegmentas);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void arIvestasSegmentasValidus()
        {
            var fake = "AAA";
            var expected = true;
            var actual = _05_DNR_inzinerija.Program.arIvestasSegmentasValidus(fake);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void segmentasPridedamasPrieDNRGalo()
        {
            var faketxt = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var fakesegmentas = "TAC";
            var expected = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT-TAC";
            var actual = _05_DNR_inzinerija.Program.segmentasPridedamasPrieDNRGalo(faketxt, fakesegmentas);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void pasalinamasSegmentas()
        {
            var faketxt = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var fakesegmentas = 1;
            var expected = "TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var actual = _05_DNR_inzinerija.Program.pasalinamasSegmentas(faketxt, fakesegmentas);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void keiciamasSegmentas()
        {
            var faketxt = "TCG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var fakesegmentNr = 1;
            var fakesegmentas = "CAG";
            var expected = "CAG-TAC-GAC-TAC-CGT-CAG-ACT-TAA-CCA-GTC-CAT-AGA-GCT";
            var actual = _05_DNR_inzinerija.Program.keiciamasSegmentas(faketxt, fakesegmentNr, fakesegmentas);
            Assert.AreEqual(expected, actual);
        }
    }
}