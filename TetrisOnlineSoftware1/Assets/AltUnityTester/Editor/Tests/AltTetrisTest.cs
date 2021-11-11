using NUnit.Framework;
using Altom.AltUnityDriver;

public class NewAltUnityTest
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver =new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }

    [Test]
    public void PruebaIntegrada()
    {
	    altUnityDriver.LoadScene("LoginAndRegister");   
        altUnityDriver.FindObject(By.NAME, "Placeholder").Click();  
        altUnityDriver.FindObject(By.NAME, "Login_Btn").Click();
        var TextoError = altUnityDriver.WaitForObject(By.NAME, "Warning_Text");
        Assert.IsTrue(TextoError.enabled);

        altUnityDriver.LoadScene("Leaderboard");
        altUnityDriver.FindObject(By.NAME, "GetLeaderboard").Click();
        altUnityDriver.FindObject(By.NAME, "PlayAgain").Click();
        altUnityDriver.WaitForCurrentSceneToBe("Tetris");



        AltUnityKeyCode Ecode = AltUnityKeyCode.E;
        AltUnityKeyCode Scode = AltUnityKeyCode.S;
        AltUnityKeyCode Qcode = AltUnityKeyCode.Q;
        AltUnityKeyCode Acode = AltUnityKeyCode.A;
        AltUnityKeyCode Dcode = AltUnityKeyCode.D;
        altUnityDriver.KeyDown(Dcode, 1);
        altUnityDriver.KeyDown(Ecode, 1); 
        altUnityDriver.KeyDown(Qcode, 1);

        altUnityDriver.LoadScene("GameOver");   
        altUnityDriver.FindObject(By.NAME, "GoToLeaderboard").Click();
        altUnityDriver.WaitForCurrentSceneToBe("Leaderboard");
        altUnityDriver.Stop();

    }

    [Test]
    public void TestTetrisIzq()
    {
	    altUnityDriver.LoadScene("Tetris");  
        AltUnityKeyCode Acode = AltUnityKeyCode.A;
        altUnityDriver.KeyDown(Acode, 1);
        altUnityDriver.Stop();
    }
    [Test]
    public void TestTetrisDer()
    {
	    altUnityDriver.LoadScene("Tetris");  
        AltUnityKeyCode Dcode = AltUnityKeyCode.D;
        altUnityDriver.KeyDown(Dcode, 1);
        altUnityDriver.Stop();
    }
    [Test]
    public void TestTetrisRotQ()
    {
	    altUnityDriver.LoadScene("Tetris");  
        AltUnityKeyCode Qcode = AltUnityKeyCode.Q;
        altUnityDriver.KeyDown(Qcode, 1);
        altUnityDriver.Stop();
    }
    [Test]
    public void TestTetrisRotE()
    {
	    altUnityDriver.LoadScene("Tetris");  
        AltUnityKeyCode Ecode = AltUnityKeyCode.E;
        altUnityDriver.KeyDown(Ecode, 1);
        altUnityDriver.Stop();
    }
    [Test]
    public void TestTetrisDrop()
    {
	    altUnityDriver.LoadScene("Tetris");  
        AltUnityKeyCode Spacode = AltUnityKeyCode.Space;
        altUnityDriver.KeyDown(Spacode, 1);
        altUnityDriver.Stop();
    }
    [Test]
    public void TestTetrisAbj()
    {
	    altUnityDriver.LoadScene("Tetris");  
        AltUnityKeyCode Scode = AltUnityKeyCode.S;
        altUnityDriver.KeyDown(Scode, 1);
        altUnityDriver.Stop();
    }
}