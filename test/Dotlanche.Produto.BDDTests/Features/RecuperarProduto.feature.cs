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
                global::Reqnroll.Table table3 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria",
                            "idCategoria"});
                table3.AddRow(new string[] {
                            "a0a518e4-f51c-4ca6-94a7-f343c1a1b338",
                            "Lanche A",
                            "Um lanche para testar",
                            "14,99",
                            "Lanche",
                            "1"});
                table3.AddRow(new string[] {
                            "0dabcc03-e5a0-407b-a876-d65b6c05c23c",
                            "Bebida A",
                            "Outra bebida de teste",
                            "19,99",
                            "Bebida",
                            "2"});
#line 4
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table3, "Dado ");
#line hidden
#line 8
  await testRunner.WhenAsync("for consultado o produto com id a0a518e4-f51c-4ca6-94a7-f343c1a1b338", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 9
  await testRunner.ThenAsync("deve retornar o produto Lanche A", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
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
                global::Reqnroll.Table table4 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria",
                            "idCategoria"});
                table4.AddRow(new string[] {
                            "a0a518e4-f51c-4ca6-94a7-f343c1a1b339",
                            "Lanche B",
                            "Um lance pra testares",
                            "16,99",
                            "Lanche",
                            "1"});
                table4.AddRow(new string[] {
                            "0dabcc03-e5a0-407b-a876-d65b6c05c23d",
                            "Bebida B",
                            "Outra bebid de testes",
                            "18,99",
                            "Bebida",
                            "2"});
#line 12
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table4, "Dado ");
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
        [NUnit.Framework.DescriptionAttribute("Recuperar um produto existente pelo nome")]
        public async System.Threading.Tasks.Task RecuperarUmProdutoExistentePeloNome()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Recuperar um produto existente pelo nome", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
                global::Reqnroll.Table table5 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria",
                            "idCategoria"});
                table5.AddRow(new string[] {
                            "90a518e4-f51c-4ca6-94a7-f343c1a1b338",
                            "Lanche C",
                            "Um lanche para testar",
                            "17,99",
                            "Lanche",
                            "1"});
                table5.AddRow(new string[] {
                            "9dabcc03-e5a0-407b-a876-d65b6c05c23c",
                            "Bebida C",
                            "Outra bebida de teste",
                            "12,99",
                            "Bebida",
                            "2"});
#line 20
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table5, "Dado ");
#line hidden
#line 24
  await testRunner.WhenAsync("for consultado o produto com nome Lanche C", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 25
  await testRunner.ThenAsync("deve retornar o produto Lanche C", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
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
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table6 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria",
                            "idCategoria"});
                table6.AddRow(new string[] {
                            "b0a518e4-f51c-4ca6-94a7-f343c1a1b339",
                            "Lanche D",
                            "Um lanche para testar",
                            "16,99",
                            "Lanche",
                            "1"});
                table6.AddRow(new string[] {
                            "1dabcc03-e5a0-407b-a876-d65b6c05c23d",
                            "Bebida D",
                            "Bebida de teste",
                            "8,99",
                            "Bebida",
                            "2"});
#line 28
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table6, "Dado ");
#line hidden
#line 32
  await testRunner.WhenAsync("for consultado a lista de produtos com ids b0a518e4-f51c-4ca6-94a7-f343c1a1b339,1" +
                        "dabcc03-e5a0-407b-a876-d65b6c05c23d", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 33
  await testRunner.ThenAsync("deve retornar os produtos Lanche D e Bebida D", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Recuperar produtos em categoria")]
        public async System.Threading.Tasks.Task RecuperarProdutosEmCategoria()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Recuperar produtos em categoria", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
                global::Reqnroll.Table table7 = new global::Reqnroll.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Price",
                            "Categoria",
                            "idCategoria"});
                table7.AddRow(new string[] {
                            "99a518e4-f51c-4ca6-94a7-f343c1a1b339",
                            "Lanche E",
                            "Um lanche para testar",
                            "22,99",
                            "Lanche",
                            "1"});
                table7.AddRow(new string[] {
                            "99abcc03-e5a0-407b-a876-d65b6c05c23d",
                            "Bebida E",
                            "Bebida de teste",
                            "13,99",
                            "Bebida",
                            "2"});
#line 36
  await testRunner.GivenAsync("produtos cadastrado:", ((string)(null)), table7, "Dado ");
#line hidden
#line 40
  await testRunner.WhenAsync("for consultado a lista de produtos de categoria 1", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 41
  await testRunner.ThenAsync("deve retornar produtos com a categoria Lanche", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
