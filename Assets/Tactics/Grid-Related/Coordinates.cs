using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates
{
  public int x;
  
  public int z;

  public Coordinates(int xCord, int zCord) {
    x = xCord;
    
    z = zCord;
  }

  public static Queue<Coordinates> operator +(int range, Coordinates startCord) {
Queue<Coordinates> newCords = new Queue<Coordinates>();
newCords.Enqueue(new Coordinates(startCord.x + range, startCord.z));
newCords.Enqueue(new Coordinates(startCord.x - range, startCord.z));
newCords.Enqueue(new Coordinates(startCord.x, startCord.z + range));
newCords.Enqueue(new Coordinates(startCord.x, startCord.z - range));
return(newCords);
  }

  public override int GetHashCode() {
    return x.GetHashCode() ^ z.GetHashCode();
  }

  public override bool Equals(object obj) {
    if (!(obj is Coordinates)) {
        return false;
    }

    Coordinates other = (Coordinates)obj;
    return x == other.x && z == other.z;
  }
}
