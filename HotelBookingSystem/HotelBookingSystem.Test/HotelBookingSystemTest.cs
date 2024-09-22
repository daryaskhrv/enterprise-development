namespace HotelBookingSystem.Domain.Test;

/// <summary>
/// �����
/// </summary>
public class HotelBookingSystemTest(TestData testData) : IClassFixture<TestData>
{

    private readonly TestData _testData = testData;
    
    /// <summary>
    /// ���������� � ���� ������
    /// </summary>
    [Fact]
    public void InfoAllHotels()
    {
        var result = _testData.Hotels;

        Assert.Equal("�����", result[0].Name);
        Assert.Equal("�����", result[1].Name);
        Assert.Equal("�����", result[2].Name);
        Assert.Equal("������", result[3].Name);
        Assert.Equal("���", result[4].Name);
        Assert.Equal("��������", result[5].Name);
        Assert.Equal("����", result[6].Name);
    }

    /// <summary>
    /// ��� ������� � ��������� �����, ����������� �� ���
    /// </summary>
    [Fact]
    public void InfoClientsInHotels()
    {
        var hotelClients = _testData.HotelClients.Where(client => client.Brooms.Any(broom => _testData.Rooms
                .FirstOrDefault(room => room.Id == broom.RoomId)
                .HotelID == _testData.Hotels
                .FirstOrDefault(hotel => hotel.Name == "�����")?.Id))
                .OrderBy(client => client.Surname) 
                .ThenBy(client => client.Name)
                .ThenBy(client => client.Patronymic)
                .ToList();

        Assert.True(hotelClients.Any());
        Assert.Equal("�������", hotelClients[0].Surname);
        Assert.Equal("���������", hotelClients[1].Surname);
    }

    /// <summary>
    /// ��� 5 ������ � ������� ������ ������������
    /// </summary>
    [Fact]
    public void TopHotels()
    {

        var topHotels = _testData.Hotels
    .OrderByDescending(hotel => hotel.Id == _testData.Rooms
        .Where(room => room.BookedRooms.Any())
        .Select(room => room.HotelID)
        .Distinct()
        .Count(id => id == hotel.Id))
    .Take(5)
    .Select(hotel => new {
        HotelName = hotel.Name,
        BookingCount = _testData.Rooms
        .Where(room => room.HotelID == hotel.Id)
        .SelectMany(room => room.BookedRooms)
        .Count()
    })
    .ToList();/*
        var hotelBookingCounts = _testData.Rooms
            .Where(room => room.BookedRooms.Any())
            .GroupBy(room => room.HotelID)
            .ToDictionary(
                g => g.Key,
                g => g.Select(room => room.HotelID).Distinct().Count()
            );

        var topHotels = _testData.Hotels
            .OrderByDescending(hotel => hotelBookingCounts[hotel.Id])
            .Take(5)
            .Select(hotel => new { HotelName = hotel.Name, BookingCount = hotelBookingCounts[hotel.Id] })
            .ToList();*/

        Assert.Equal("�����", topHotels[0].HotelName);
    }
}

/*Id = 1, Name = "�����", City = "������", Address = "��. ������, 1" },
        new(){ Id = 2, Name = "�����", City = "�����-���������", Address = "������� ��., 123" },
        new(){ Id = 3, Name = "�����", City = "�����-���������", Address = "��. �������, 45" },
        new(){ Id = 4, Name = "������", City = "������", Address = "��. ���������, 111" },
        new(){ Id = 5, Name = "���", City = "������", Address = "��. ������, 12" },
        new(){ Id = 6, Name = "��������", City = "������", Address = "��. ���������, 34" },
        new(){ Id = 7, Name = "����",*/