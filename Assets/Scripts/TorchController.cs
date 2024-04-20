using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchController : MonoBehaviour
{
    [SerializeField] private Light torch;
    [SerializeField] Image image;
    private bool isTorch = false;
    public float timer = 0f;
    public float spawnTimer = 0f;
    public float duration = 180f; // 3 dakika
    public GameObject[] batteries;

    public CrossHairController crossHairController;

    [Header("Spawner")]
    public GameObject battery;
    public Transform[] transforms;

    public void Update()
    {
        StartCoroutine(Evaluate());
       
        if (isTorch)
        {
            timer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
            image.fillAmount = 1f - timer / duration;
            
        }
        if(crossHairController.count==1)
        {
            timer = 0f;
            image.fillAmount = 1f;
        }
        if (!isTorch && Input.GetKeyDown(KeyCode.Mouse1) && crossHairController.isBattery)
        {
            torch.enabled = true;
            isTorch = true;

        }
        else if (isTorch && Input.GetKeyDown(KeyCode.Mouse1) && crossHairController.isBattery)
        {
            torch.enabled = false;
            isTorch = false;
        }

        if (timer > duration)
        {
            crossHairController.isBattery = false;
            torch.enabled = false;
            timer = 0f;
            isTorch = false;
        }

        if(spawnTimer > 30f)
        {
            spawnTimer = 0f;
            SpawnObject();

        }
        if (crossHairController.isBattery)
        {

            image.color = HexToColor("210A35");
        }
        else
        {
            image.color = Color.gray;

        }
    }

    private IEnumerator Evaluate()
    {
        yield return new WaitForSeconds(3);
        crossHairController.count= 0;
    }
    private Color HexToColor(string hex)
    {
        // "0x" �n ekiyle ba�layan HEX kodunu ayr��t�r
        int r = int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        int g = int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        int b = int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        // RGBA de�erlerini 0-1 aral���na normalize et
        float rf = r / 255f;
        float gf = g / 255f;
        float bf = b / 255f;

        // Olu�turulan renk
        return new Color(rf, gf, bf);
    }

    void SpawnObject()
    {
        // Rastgele bir spawn noktas� se�
        int randomIndex = Random.Range(0, transforms.Length);
        Transform selectedSpawnPoint = transforms[randomIndex];

        // Olu�turulacak objeyi instantiate et
        GameObject spawnedObject = Instantiate(battery, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
    }

}
