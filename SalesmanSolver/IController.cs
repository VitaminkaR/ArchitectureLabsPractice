namespace SalesmanSolver
{
    internal interface IController
    {
        void SetView(IView view);
        void SetModel(IModel model);
    }
}
