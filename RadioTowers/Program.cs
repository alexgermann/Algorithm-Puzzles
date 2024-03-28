#region Test Cases
// Original test case
List<int> listenerLocations = [1, 5, 11, 20];
List<int> towerLocations = [4, 8, 15];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test moving past multiple towers for one listener
listenerLocations = [1, 5, 11, 20];
towerLocations = [4, 8, 15, 18, 20];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test moving past multiple towers for multiple listeners
listenerLocations = [1, 5, 11, 20, 29];
towerLocations = [4, 8, 15, 18, 20, 22, 33];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test that unnecessary towers are skipped
listenerLocations = [1, 5, 11, 20, 29];
towerLocations = [4, 8, 15, 18, 20, 22, 33, 35, 37, 40, 41, 42, 44, 50];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test minimum distance with one listener and one tower
listenerLocations = [1];
towerLocations = [10];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test minimum distance with one listener and multiple towers
listenerLocations = [10];
towerLocations = [4, 8, 15];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test minimum distance with multiple listeners and one tower
listenerLocations = [1, 5, 11, 15];
towerLocations = [5];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

// Test identical listener and tower locations
listenerLocations = [1, 5, 11, 20];
towerLocations = [1, 5, 11, 20];
TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

//// Test bad data
//listenerLocations = [];
//towerLocations = [4, 8, 15];
//TestRadioTowerMinimumDistance(listenerLocations, towerLocations);

void TestRadioTowerMinimumDistance(List<int> listenerLocations, List<int> towerLocations)
{
    Console.WriteLine($"Listener Locations: {string.Join(", ", listenerLocations)}");
    Console.WriteLine($"Tower Locations: {string.Join(", ", towerLocations)}");
    Console.WriteLine($"Minimum Tower Distance: {GetMinimumTowerDistance(listenerLocations, towerLocations)}");
    Console.WriteLine();
}

#endregion

int GetMinimumTowerDistance(List<int> listenerLocations, List<int> towerLocations)
{
    if (listenerLocations == null || listenerLocations.Count == 0 || towerLocations == null || towerLocations.Count == 0)
    {
        throw new ArgumentException("Listener and tower locations must be non-empty.");
    }
    int minimumDistance = 0;
    int currentTowerIndex = 0;
    foreach (var listener in listenerLocations)
    {
        // Get distance to current tower, compare against distance to next tower if available
        int currentTowerDistance = Math.Abs(listener - towerLocations[currentTowerIndex]);
        while (currentTowerIndex < towerLocations.Count - 1)
        {
            int nextTowerDistance = Math.Abs(listener - towerLocations[currentTowerIndex + 1]);
            if (nextTowerDistance < currentTowerDistance)
            {
                // Next tower is closer, move to next tower
                currentTowerIndex++;
                currentTowerDistance = nextTowerDistance;
            }
            else
            {
                // Next tower is further away, don't search further
                break;
            }
        }
        // If the minimum distance to current listener is greater than the current minimum, update the minimum
        minimumDistance = Math.Max(minimumDistance, currentTowerDistance);
    }
    return minimumDistance;
}