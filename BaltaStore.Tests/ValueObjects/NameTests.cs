


using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{

  [TestClass]
  public class NameTests
  {


    private Name _validName;
    private Name _invalidName;

    public NameTests(){
      _validName = new Name("NomeTeste", "SobrenomeTeste");
      _invalidName = new Name("", "");

    }


    [TestMethod]
    public void ShouldReturnNotificationWhenNameIsInvalid(){

      Assert.AreEqual(false, _invalidName.IsValid);

    }

    [TestMethod]
    public void ShouldNotReturnNotificationWhenNameIsValid(){

      Assert.AreEqual(true, _validName.IsValid);

    }


  }
}