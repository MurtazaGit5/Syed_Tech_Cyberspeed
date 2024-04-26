// https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.UI.LayoutGroup.html
//I follow the above unity docs to create a layout group

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LayoutCardGrid : LayoutGroup   //Abstract class
{
    public int rows;    // store the rows value as integer
    public int colums;   // store the colum value as integer

    public Vector2 cardsize;    //as our coardinate system is x and y only so used vector2. cardsize variable will set value of rows and colums

    public Vector2 Spacing; // To space between multiple picture

    public int prefferedtoppadding; // Set top padding by default
    public override void CalculateLayoutInputVertical()
    {
        if(rows==0 || colums == 0)
        {
            rows = 4;
            colums = 5;
        }

        float parentwidth = rectTransform.rect.width;
        float parenheight = rectTransform.rect.height;

        float cellHeight = (parenheight-2 * prefferedtoppadding-Spacing.y*(rows-1)) / rows;
        float cellwidth = cellHeight;

        // If different aspect ration it will fix by using if condition
        if (cellwidth * colums + Spacing.x * (colums - 1) > parentwidth)
        {
            cellwidth = (parentwidth - 2 * prefferedtoppadding - (colums - 1) * Spacing.x) / colums;
            cellHeight = cellwidth;
        }

        cardsize = new Vector2(cellwidth, cellHeight);
        //cardsize.x = cellwidth;
        //cardsize.y = cellHeight;

        padding.left = Mathf.FloorToInt((parentwidth-colums*cellwidth-Spacing.x * (colums-1))/1.5f);
        padding.top = Mathf.FloorToInt((parenheight - rows * cellHeight - Spacing.y * (rows - 1)) / 1.5f);
        padding.bottom = padding.top;

        for(int i = 0; i < rectChildren.Count; i++)
        {
            int rowcount = i / colums;
            int coloumcount = i % colums;

            var item = rectChildren[i];

            var xpos = padding.left+ cardsize.x * coloumcount + Spacing.x * (coloumcount-1);
            var ypos = padding.top+ cardsize.y * rowcount +Spacing.y * (rowcount-1);

            SetChildAlongAxis(item,0,xpos,cardsize.x);
            SetChildAlongAxis(item, 1, ypos, cardsize.y);
        }
    }

    public override void SetLayoutHorizontal()
    {
        return;
    }

    public override void SetLayoutVertical()
    {
        return;
    }
}
