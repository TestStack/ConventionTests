TestStack.ConventionTests
=========================

### What is ConventionTests?
Convention over Configuration is a great way to cut down repetitive boilerplate code. 
But how do you validate that your code adheres to your conventions? 
TestStack.ConventionTests is a simple NuGet library that makes it easy to build validation rules for convention validation tests.

TestStack.ConventionTests also will generate a convention report of the conventions present in your codebase, which you can publish as **living documentation**

### Using Con­ven­tion­Tests

    [Test]
    public void DomainHasVirtualMethodsConvention()
    {
	    // Define some data
	    var nHibernateEntities = Tpes.InAssemblyOf<SampleDomainClass>()
                .ConcreteTypes().InNamespace(typeof (SampleDomainClass).Namespace)
                .ToTypes("nHibernate Entitites");

        // Apply convention to data
	    Convention.Is(new AllMethodsAreVirtual(), nhibernateEntities);
    }

For more information [view the TestStack.ConventionTests documentation](http://docs.teststack.net/conventiontests/index.html)

### Packaged Conventions
Here is a list of some of the pacakged conventions

 - **AllClassesHaveDefaultConstructor** - All classes in defined data must have a default ctor (protected or public)
 - **AllMethodsAreVirtual** - All classes in defined data must have virtual methods (includes get_Property/set_Property backing methods)
 - **ClassTypeHasSpecificNamespace** - For example, Dto's must live in the Assembly.Dtos namespace'
 - **FilesAreEmbeddedResources** - All .sql files are embedded resources
 - **ProjectDoesNotReferenceDllsFromBinOrObjDirectories** - Specified project file must not reference assemblies from bin/obj directory
 - **MvcControllerNameAndBaseClassConvention** - Enforces MVC controller naming conventions
    - Types ending in *Controller must inherit from Controller (or ApiController), and
	- Types inheriting from ControllerBase must be named *Controller
 - **MvcControllerNameAndBaseClassConvention** - Enforces WebApi controller naming conventions
    - Types ending in *Controller must inherit from ApiController (or Controller), and
	- Types inheriting from ApiController must be named *Controller

If you would like to define your own conventions see [Defining Conventions](http://docs.teststack.net/ConventionTests/DefiningConventions.html)

### Where to find out more
[Krzysztof Koźmic](https://github.com/kkozmic) spoke about ConventionTests at NDC 2012. You can find the video of that talk [here](http://vimeo.com/43676874), slides [here](http://kozmic.pl/presentations/) and the introductory blog post [here](http://kozmic.pl/2012/06/14/using-conventiontests/).

[TestStack.ConventionTests documentation](http://docs.teststack.net/conventiontests/index.html)