﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dotlanche.Produto.BDDTests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Recuperar Produto existente")]
    public partial class RecuperarProdutoExistenteFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Features", "Recuperar Produto existente", null, global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "RecuperarProduto.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
            {
                await testRunner.OnFeatureEndAsync();
            }
            if ((testRunner.FeatureContext == null))
            {
                await testRunner.OnFeatureStartAsync(featureInfo);
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
            global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Recuperar um produto existente")]
        public async System.Threading.Tasks.Task RecuperarUmProdutoExistente()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Recuperar um produto existente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria"});
                table1.AddRow(new string[] {
                            "a0a518e4-f51c-4ca6-94a7-f343c1a1b338",
                            "Lanche A",
                            "Um lanche para testar",
                            "14,99",
                            "Lanche"});
                table1.AddRow(new string[] {
                            "0dabcc03-e5a0-407b-a876-d65b6c05c23c",
                            "Lanche B",
                            "Outro lanche de teste",
                            "19,99",
                            "Lanche"});
#line 4
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table1, "Dado ");
#line hidden
#line 8
  await testRunner.WhenAsync("for consultado o produto com id a0a518e4-f51c-4ca6-94a7-f343c1a1b338", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 9
  await testRunner.ThenAsync("deve retornar o produto", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Recuperar um produto inexistente")]
        public async System.Threading.Tasks.Task RecuperarUmProdutoInexistente()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Recuperar um produto inexistente", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table2 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria"});
                table2.AddRow(new string[] {
                            "a0a518e4-f51c-4ca6-94a7-f343c1a1b339",
                            "Lanche C",
                            "Um lance pra testares",
                            "16,99",
                            "Lanche"});
                table2.AddRow(new string[] {
                            "0dabcc03-e5a0-407b-a876-d65b6c05c23d",
                            "Lanche D",
                            "Outro lance de testes",
                            "18,99",
                            "Lanche"});
#line 12
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table2, "Dado ");
#line hidden
#line 16
  await testRunner.WhenAsync("for consultado o produto com id a0a518e4-f51c-4ca6-94a7-aaaaaaaaaaaa", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 17
  await testRunner.ThenAsync("deve retornar status não encontrado", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Recuperar produtos em lista de pedido")]
        public async System.Threading.Tasks.Task RecuperarProdutosEmListaDePedido()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Recuperar produtos em lista de pedido", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table3 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria"});
                table3.AddRow(new string[] {
                            "b0a518e4-f51c-4ca6-94a7-f343c1a1b339",
                            "Lanche E",
                            "Um lanche para testar",
                            "16,99",
                            "Lanche"});
                table3.AddRow(new string[] {
                            "1dabcc03-e5a0-407b-a876-d65b6c05c23d",
                            "Bebida A",
                            "Bebida de teste",
                            "8,99",
                            "Bebida"});
#line 20
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table3, "Dado ");
#line hidden
#line 24
  await testRunner.WhenAsync("for consultado a lista de produtos com ids b0a518e4-f51c-4ca6-94a7-f343c1a1b339,1" +
                        "dabcc03-e5a0-407b-a876-d65b6c05c23d", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 25
  await testRunner.ThenAsync("deve retornar os produtos", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
