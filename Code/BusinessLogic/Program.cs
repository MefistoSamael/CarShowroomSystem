
using BusinessLogic.Application;
using BusinessLogic.Controller;
using BusinessLogic.Model;
using BusinessLogic.View;


Model model = new Model();  

Controller controller = new Controller(model);

ConsoleView consoleView = new ConsoleView(controller);

consoleView.Main();
//controller.InputInvite();
//model.Registrate("Ivan228336", "1234", Roles.customer, "Ivan  Zalupko");

//foreach (var item in model.GetAllProducts())
//    Console.WriteLine(item.Name + "\n");


//int a = 0;
