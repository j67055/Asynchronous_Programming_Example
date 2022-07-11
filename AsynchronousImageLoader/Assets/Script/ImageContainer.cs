using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ImageContainer : MonoBehaviour
{
    public UnityEngine.UI.Image image;

    private bool isLoaded;

    public async Task loadImageAsync()
    {
        if (isLoaded) return;

        isLoaded = true;
        await Task.Delay(Random.Range(500, 1300));
        image.color = Random.ColorHSV();
    }

    public void loadImageSync()
    {
        if(isLoaded) return;

        isLoaded = true;
        Task.Delay(Random.Range(10, 30)).Wait();
        image.color = Random.ColorHSV();
    }

    public void loadWithCoroutine() 
        => StartCoroutine(loadImage());

    private IEnumerator loadImage()
    {
        isLoaded = true;
        Task.Delay(Random.Range(10, 30)).Wait();
        image.color = Random.ColorHSV();

        yield break;
    }

    public void reset()
    {
        image.color = Color.white;
        isLoaded = false;
    }
}
