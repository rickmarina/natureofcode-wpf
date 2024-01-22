namespace NatureOfCode.Models;

 public interface IScenario
 {
    string GetTitle();
     void Draw();
     void Update(long delta);
 }