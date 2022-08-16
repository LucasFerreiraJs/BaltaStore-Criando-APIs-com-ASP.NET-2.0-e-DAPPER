


using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
  [TestClass]
  public class DocumentTests
  {

    private Document _validDocument;
    private Document _invalidDocument;

    public DocumentTests(){

      _validDocument = new Document("28659170377");
      _invalidDocument = new Document("12345678910");

    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {

      // var document = new Document("12345678910");
      Assert.AreEqual(false, _invalidDocument.IsValid);
    }


    [TestMethod]
    public void ShouldreturnNotNotificationWhenDocumentIsValid()
    {
      // var document = new Document("28659170377");
      Assert.AreEqual(true, _validDocument.IsValid);
    }
  }
}