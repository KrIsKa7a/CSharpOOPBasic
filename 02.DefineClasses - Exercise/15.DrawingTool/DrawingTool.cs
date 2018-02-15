using System;
using System.Collections.Generic;
using System.Text;

public class DrawingTool
{
    private Square square;
    private Rectangle rectangle;

    public DrawingTool(Square square)
    {
        this.square = square;
    }

    public DrawingTool(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    public void DrawFigure()
    {
        if (square == null)
        {
            this.rectangle.Draw();
        }
        else
        {
            this.square.Draw();
        }
    }
}
