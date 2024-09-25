// See https://aka.ms/new-console-template for more information
using CWDesign;

Console.WriteLine("Hello, World!");


//单例
Console.WriteLine("CWSingleton.Instance.id" + CWSingleton.Instance.id);

//简单工厂
CWSimpleFactory.Main();

//工厂方法
CWFactoryMethod.Main();

//抽象工厂
CWAbstractFactory.Main();

//建造者模式
CWBuilder.Main();

//原型模式
CWPrototype.Main();

//适配器模式
CWAdapter.Main();

//桥接模式
CWBridge.Main();

//装饰器模式
CWDecorator.Main();

//组合模式
CWComposite.Main();

//外观模式
CWFacade.Main();

//享元模式
CWFlyweight.Main();

//代理模式
CWProxy.Main();

//模版方法
CWTemplateMethod.Main();




