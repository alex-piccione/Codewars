
import main
import unittest


class Test(unittest.TestCase):

    def test_when_no_element(self):

        # Arrange
        distances = []
        cities = 100
        distance_limit = 100
        expected_result = None

        # Act
        result = main.get_max_distances(distances, cities, distance_limit)

        # Assert
        self.assertEqual(expected_result, result, "Expected: {0}, Result: {1}".format(expected_result, result))

    def test_when_one_element(self):

        # Arrange
        distances = [3]
        cities = 100
        distance_limit = 100
        expected_result = 3

        # Act
        result = main.get_max_distances(distances, cities, distance_limit)

        # Assert
        self.assertEqual(expected_result, result, "Expected: {0}, Result: {1}".format(expected_result, result))

    def test_simple_case(self):

        # Arrange
        distances = [1, 2, 3]
        cities = 2
        distance_limit = 2
        expected_result = 2

        # Act
        result = main.get_max_distances(distances, cities, distance_limit)

        # Assert
        self.assertEqual(expected_result, result, "Expected: {0}, Result: {1}".format(expected_result, result))

    def test_distances_when_ordered(self):

        # Arrange
        distances = [50, 55, 57, 58, 60]
        cities = 3
        distance_limit = 174
        expected_result = 173

        # Act
        result = main.get_max_distances(distances, cities, distance_limit)

        # Assert
        self.assertEqual(expected_result, result, "Expected: {0}, Result: {1}".format(expected_result, result))

    def test_distances_when_unordered(self):

        # Arrange
        distances = [57, 50, 55, 60, 58]
        cities = 3
        distance_limit = 174
        expected_result = 173

        # Act
        result = main.get_max_distances(distances, cities, distance_limit)

        # Assert
        self.assertEqual(expected_result, result, "Expected: {0}, Result: {1}".format(expected_result, result))

    def test_when_many_distancies(self):

        # Arrange
        distances = [91, 74, 73, 85, 73, 81, 87]
        cities = 3
        distance_limit = 230
        expected_result = 228

        # Act
        result = main.get_max_distances(distances, cities, distance_limit)

        # Assert
        self.assertEqual(expected_result, result, "Expected: {0}, Result: {1}".format(expected_result, result))


if __name__ == "__main__":

    unittest.main()