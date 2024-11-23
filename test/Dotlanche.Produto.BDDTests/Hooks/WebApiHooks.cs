using Dotlanche.Produto.BDDTests.Setup;

namespace Dotlanche.Produto.BDDTests.Hooks;

[Binding]
public static class WebApiHooks
{
    private static ProdutoApi? _produtoApi;

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        _produtoApi = new ProdutoApi();
        featureContext.FeatureContainer.RegisterInstanceAs(_produtoApi, dispose: true);
    }

    [AfterFeature]
    public static void AfterFeature()
    {
        _produtoApi?.Dispose();
    }
}