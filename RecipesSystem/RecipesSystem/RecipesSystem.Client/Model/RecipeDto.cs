using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace RecipesSystem.Client.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class RecipeDto {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public int? Id { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets Description
    /// </summary>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or Sets Country
    /// </summary>
    [DataMember(Name="country", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    /// <summary>
    /// Gets or Sets Ingredients
    /// </summary>
    [DataMember(Name="ingredients", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "ingredients")]
    public string Ingredients { get; set; }

    /// <summary>
    /// Gets or Sets Year
    /// </summary>
    [DataMember(Name="year", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "year")]
    public int? Year { get; set; }

    /// <summary>
    /// Gets or Sets Calories
    /// </summary>
    [DataMember(Name="calories", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "calories")]
    public int? Calories { get; set; }

    /// <summary>
    /// Gets or Sets RowVersion
    /// </summary>
    [DataMember(Name="rowVersion", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rowVersion")]
    public byte[] RowVersion { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class RecipeDto {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  Country: ").Append(Country).Append("\n");
      sb.Append("  Ingredients: ").Append(Ingredients).Append("\n");
      sb.Append("  Year: ").Append(Year).Append("\n");
      sb.Append("  Calories: ").Append(Calories).Append("\n");
      sb.Append("  RowVersion: ").Append(RowVersion).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
