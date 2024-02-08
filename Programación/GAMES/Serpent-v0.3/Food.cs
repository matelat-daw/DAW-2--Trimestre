public class Food
{
    private int x_food;
    private int y_food;
    private Random coords = new Random();

    public Food()
    {
        this.x_food = coords.Next(20, 101);
        this.y_food = coords.Next(5, 31);
    }

    public int getx_food
    {
        get { return x_food; }
    }

    public int gety_food
    {
        get { return y_food; }
    }
}