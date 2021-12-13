
def main():

    print("Press any key to close...")
    input()


def get_max_distances(distances, cities, distance_limit):

    current_distance = 0
    city_counter = 0

    distances.sort()
    distances.reverse()

    for distance in distances:
        
        if current_distance < distance_limit and city_counter < cities:   
            if current_distance + distance <= distance_limit:
                current_distance += distance
                city_counter += 1
        else:
            break

    return current_distance or None


if __name__ == "__main__":

    main()