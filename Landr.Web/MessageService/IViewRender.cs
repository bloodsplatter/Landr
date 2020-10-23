namespace Landr.Web.MessageService
{
    public interface IViewRender
    {
        string Render<TModel>(string name, TModel model);
    }
}