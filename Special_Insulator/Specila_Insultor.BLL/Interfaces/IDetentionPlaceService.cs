using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IDetentionPlaceService
    {
        bool AddDetentionPlace(DetentionPlace place);

        List<DetentionPlace> GetAllDetentionPlaces();

        List<DetentionPlace> GetAllDetentionPlacesAndSwap(int? Id);

        DetentionPlace GetDetentionPlaceById(int? Id);

        bool DeleteDetentionPlaceById(int? Id);

        bool EditDetentionPlace(DetentionPlace place);

        bool IsNewPlace(string address);

        bool IsUsing(int? Id);
    }
}
