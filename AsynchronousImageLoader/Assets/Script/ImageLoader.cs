using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public enum LoadType { Async, Sync, Coroutine };

    public ScrollRect scrollRect;
    public GridLayoutGroup gridLayoutGroup;
    public LoadType loadType;

    private List<ImageContainer> cards = new List<ImageContainer>();
    private int startIdx;

    private void Awake()
    {
        scrollRect.onValueChanged.AddListener(ScrollRect_OnChanged);
        foreach(RectTransform c in scrollRect.content)
            cards.Add(c.GetComponent<ImageContainer>());
    }

    private void Start() 
        => Invoke("loadImage", 0.1f);

    public void loadImage()
    {
        int endIdx = getLastIdxToLoad();
        loadImage(endIdx);
        startIdx = Mathf.Max(startIdx, endIdx);
    }

    public void reset()
    {
        cards.ForEach(e => e.reset());
        startIdx = 0;
        scrollRect.verticalNormalizedPosition = 1;

        loadImage();
    }

    private int getLastIdxToLoad()
    {
        float normalizedCurrentPosY = 1 - scrollRect.verticalNormalizedPosition;
        Rect viewportRect = scrollRect.viewport.rect;
        Rect contentRect = scrollRect.content.rect;
        float startY = contentRect.y + viewportRect.height;
        float endY = contentRect.y + contentRect.height;
        float currentPosY = startY + (endY - startY) * normalizedCurrentPosY;
        RectOffset padding = gridLayoutGroup.padding;
        Vector2 cellSize = gridLayoutGroup.cellSize;
        Vector2 spacing = gridLayoutGroup.spacing;
        int columnCount = gridLayoutGroup.constraintCount;
        int height = Mathf.CeilToInt((currentPosY - contentRect.y - padding.top) / (cellSize.y + spacing.y));
        int contentsCount = gridLayoutGroup.transform.childCount;
        
        return Mathf.Min(contentsCount, height * columnCount);
    }

    private void loadImage(int endIdx)
    {
        switch (loadType)
        {
            case LoadType.Async:
                for (int i = startIdx; i < endIdx; i++)
                    cards[i].loadImageAsync();
                break;
            case LoadType.Sync:
                for (int i = startIdx; i < endIdx; i++)
                    cards[i].loadImageSync();
                break;
            case LoadType.Coroutine:
                for (int i = startIdx; i < endIdx; i++)
                    cards[i].loadWithCoroutine();
                break;
        }
    }

    private void ScrollRect_OnChanged(Vector2 pos)
        => loadImage();
}
