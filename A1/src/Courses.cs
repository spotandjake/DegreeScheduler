using System.Collections.Generic;
using System.Text.Json;

namespace CourseGraph {

  public class Course {
    public int ID { get; }
    public string Name { get; }
    /// <summary>
    /// Marks weather a course is real or just an informative node.
    /// A phantom course may for instance be a degree field or root node.
    /// </summary>
    public bool IsPhantom { get; }
    public List<Course> CoRequisites { get; }
    public List<Course> PreRequisites { get; }
    // NOTE: Simplification, if a course is a pre-requisite to the phantom degree course it is implcitily required
    // TODO: add term information
    // TODO: timetable information
    public Course(int id, string name, List<Course> coRequisites, List<Course> preRequisites, bool isPhantom = false) {
      this.ID = id;
      this.Name = name;
      this.IsPhantom = isPhantom;
      this.CoRequisites = coRequisites;
      this.PreRequisites = preRequisites;
    }

    public override string ToString() {
      return JsonSerializer.Serialize(this, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, WriteIndented = true });
    }
  }
}
