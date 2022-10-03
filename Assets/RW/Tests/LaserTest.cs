using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LaserTest
{

    private Game game;

    [SetUp]
    public void Setup()
    {
        GameObject gameGameObject =
          MonoBehaviour.Instantiate(
            Resources.Load<GameObject>("Prefabs/Game"));
        game = gameGameObject.GetComponent<Game>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(game.gameObject);
    }

    [UnityTest]
    public IEnumerator LaserDestroysAsteroid()
    {
        GameObject asteroid = game.GetSpawner().SpawnAsteroid();
        asteroid.transform.position = Vector3.zero;
        GameObject laser = game.GetShip().SpawnLaser();
        laser.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        UnityEngine.Assertions.Assert.IsNull(asteroid);
    }

    [UnityTest]
    public IEnumerator checkReload() //ignore shooting button
    {
        float prevShotCount = game.GetShip().shotCounter = 9;
        game.GetShip().ShootLaser();
        float shotCountAfter = game.GetShip().shotCounter;

        yield return new WaitForSeconds(0.2f);

        Assert.AreEqual(prevShotCount, shotCountAfter);
    }
}


