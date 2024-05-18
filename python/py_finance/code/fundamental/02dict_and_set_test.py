def test_create():
    d1 = {'name': 'chris', 'age': 30, 'gender': 'male'}
    d2 = dict({'name': 'chris', 'age': 30, 'gender': 'male'})
    d3 = dict([('name', 'chris'), ('age', 30), ('gender', 'male')])
    d4 = dict(name='chris', age=30, gender='male')
    assert d1 == d2


if __name__ == '__main__':
    test_create()
