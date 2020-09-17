using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {
  // Save file path
  static string path = Application.persistentDataPath + "/game";

  public static void SaveGame(ScoreManager score, int level) {
    // Create formatter and stream with the save path
    BinaryFormatter formatter = new BinaryFormatter();
    FileStream stream = new FileStream(path, FileMode.Create);
    // Build game data
    GameData data = new GameData(score, level);
    // Save the game data
    formatter.Serialize(stream, data);
    stream.Close();
  }

  public static GameData LoadGame() {
    if (File.Exists(path)) {
      // Create formatter and stream with the save path
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);
      // Load the game data
      GameData data = formatter.Deserialize(stream) as GameData;
      stream.Close();
      return data;
    } else {
      return null;
    }
  }

  public static void DeleteSave() {
    if (File.Exists(path)) {
      File.Delete(path);
    }
  }
}
