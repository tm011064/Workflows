using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WorkflowSystem.Components
{
  #region section
  public class WorkflowConfigSection : ConfigurationSection
  {
    [ConfigurationProperty("workflows")]
    [ConfigurationCollection(typeof(WorkflowCollection), AddItemName = "workflow", ClearItemsName = "clear", RemoveItemName = "remove")]
    public WorkflowCollection Workflows
    {
      get { return (WorkflowCollection)base["workflows"]; }
      set { this["workflows"] = value; }
    }
  }
  #endregion


  #region collections
  public class WorkflowCollection : ConfigurationElementCollection
  {
    public WorkflowElement this[string key]
    {
      get { return (WorkflowElement)BaseGet(key); }
      set { }
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new WorkflowElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((WorkflowElement)element).Name;
    }
  }

  public class UsingCollection : ConfigurationElementCollection
  {
    public UsingElement this[string key]
    {
      get { return (UsingElement)BaseGet(key); }
      set { }
    }

    public IEnumerable<UsingElement> Get()
    {
      for (int i = 0; i < this.Count; i++)
        yield return (UsingElement)this.BaseGet(i);
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new UsingElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((UsingElement)element).Namespace;
    }
  }
  #endregion


  #region elements
  public class WorkflowElement : ConfigurationElement
  {
    [ConfigurationProperty("name", IsKey=true, IsRequired=true)]
    public string Name
    {
      get { return (string)base["name"]; }
      set { this["name"] = value; }
    }

    [ConfigurationProperty("namespaces")]
    [ConfigurationCollection(typeof(UsingCollection), AddItemName = "using", ClearItemsName = "clear", RemoveItemName = "remove")]
    public UsingCollection Namespaces
    {
      get { return (UsingCollection)base["namespaces"]; }
      set { this["namespaces"] = value; }
    }

    [ConfigurationProperty("rundown", IsKey = true, IsRequired = true)]
    public RundownElement RundownElement
    {
      get { return (RundownElement)base["rundown"]; }
      set { this["rundown"] = value; }
    }
  }

  public class UsingElement : ConfigurationElement
  {
    [ConfigurationProperty("namespace", IsKey = true, IsRequired = true)]
    public string Namespace
    {
      get { return (string)base["namespace"]; }
      set { this["namespace"] = value; }
    }
  }

  public class RundownElement : ConfigurationElement
  {
    public string ContextType { get; private set; }
    public string Value { get; private set; }

    protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
    {
      XElement element = XElement.Parse(reader.ReadOuterXml());

      this.ContextType = element.Attribute("contextType").Value;
      this.Value = element.Value;
    }
  }
  #endregion
}
