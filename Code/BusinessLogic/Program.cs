
using BusinessLogic.Application;
using BusinessLogic.Controller;
using BusinessLogic.Entities.Products;
using BusinessLogic.Model;
using BusinessLogic.View;

Product prod = new Product();

Model model = new Model();  



Controller controller = new Controller(model);

ConsoleView consoleView = new ConsoleView(controller);

consoleView.Main();
