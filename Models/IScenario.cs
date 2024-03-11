namespace NatureOfCode.Models;

 public interface IScenario
 {
    string GetTitle();
     void Setup();
     void Update(long delta);
 }