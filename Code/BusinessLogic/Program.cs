
using BusinessLogic.Application;
using BusinessLogic.Controller;
using BusinessLogic.Entities.Products;
using BusinessLogic.Entities.Users;
using BusinessLogic.Model;
using BusinessLogic.View;

Product prod = new Product();

Model model = new Model();  



Controller controller = new Controller(model);

ConsoleView consoleView = new ConsoleView(controller);

consoleView.Main();

class Human
{
    private int age;

    public void setAge(int value)
    {
        if (value < 0 || value > 100)
            throw new Exception("Ты дурак?");

        age = value;
    }


}