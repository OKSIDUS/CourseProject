using AutoMapper;
using UserCollection.Services.Database.Entities;
using UserCollection.WebAPI.Models;

namespace UserCollection.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<CollectionEntity, CollectionModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CustomDateTimeFields, opt => opt.MapFrom(src => MapCustomFieldsModel(src.CustomDateTimeField1State, src.CustomDateTimeField1Name, src.CustomDateTimeField2State, src.CustomDateTimeField2Name, src.CustomDateTimeField3State, src.CustomDateTimeField3Name)))
                .ForMember(dest => dest.CustomBoolFields, opt => opt.MapFrom(src => MapCustomFieldsModel(src.CustomBoolField1State, src.CustomBoolField1Name, src.CustomBoolField2State, src.CustomBoolField2Name, src.CustomBoolField3State, src.CustomBoolField3Name)))
                .ForMember(dest => dest.CustomTextFields, opt => opt.MapFrom(src => MapCustomFieldsModel(src.CustomTextField1State, src.CustomTextField1Name, src.CustomTextField2State, src.CustomTextField2Name, src.CustomTextField3State, src.CustomTextField3Name)))
                .ForMember(dest => dest.CustomStringFields, opt => opt.MapFrom(src => MapCustomFieldsModel(src.CustomStringField1State, src.CustomStringField1Name, src.CustomStringField2State, src.CustomStringField2Name, src.CustomStringField3State, src.CustomStringField3Name)))
                .ForMember(dest => dest.CustomIntegerFields, opt => opt.MapFrom(src => MapCustomFieldsModel(src.CustomIntField1State, src.CustomIntField1Name, src.CustomIntField2State, src.CustomIntField2Name, src.CustomIntField3State, src.CustomIntField3Name)));


            this.CreateMap<CollectionModel, CollectionEntity>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CustomBoolField1Name, opt => opt.MapFrom(src => src.CustomBoolFields.CustomField1Name))
                .ForMember(dest => dest.CustomBoolField1State, opt => opt.MapFrom(src => src.CustomBoolFields.CustomField1State))
                .ForMember(dest => dest.CustomBoolField2Name, opt => opt.MapFrom(src => src.CustomBoolFields.CustomField2Name))
                .ForMember(dest => dest.CustomBoolField2State, opt => opt.MapFrom(src => src.CustomBoolFields.CustomField2State))
                .ForMember(dest => dest.CustomBoolField3Name, opt => opt.MapFrom(src => src.CustomBoolFields.CustomField3Name))
                .ForMember(dest => dest.CustomBoolField3State, opt => opt.MapFrom(src => src.CustomBoolFields.CustomField3State))
                .ForMember(dest => dest.CustomDateTimeField1Name, opt => opt.MapFrom(src => src.CustomDateTimeFields.CustomField1Name))
                .ForMember(dest => dest.CustomDateTimeField1State, opt => opt.MapFrom(src => src.CustomDateTimeFields.CustomField1State))
                .ForMember(dest => dest.CustomDateTimeField2Name, opt => opt.MapFrom(src => src.CustomDateTimeFields.CustomField2Name))
                .ForMember(dest => dest.CustomDateTimeField2State, opt => opt.MapFrom(src => src.CustomDateTimeFields.CustomField2State))
                .ForMember(dest => dest.CustomDateTimeField3Name, opt => opt.MapFrom(src => src.CustomDateTimeFields.CustomField3Name))
                .ForMember(dest => dest.CustomDateTimeField3State, opt => opt.MapFrom(src => src.CustomDateTimeFields.CustomField3State))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CustomStringField1Name, opt => opt.MapFrom(src => src.CustomStringFields.CustomField1Name))
                .ForMember(dest => dest.CustomStringField1State, opt => opt.MapFrom(src => src.CustomStringFields.CustomField1State))
                .ForMember(dest => dest.CustomStringField2Name, opt => opt.MapFrom(src => src.CustomStringFields.CustomField2Name))
                .ForMember(dest => dest.CustomStringField2State, opt => opt.MapFrom(src => src.CustomStringFields.CustomField2State))
                .ForMember(dest => dest.CustomStringField3Name, opt => opt.MapFrom(src => src.CustomStringFields.CustomField3Name))
                .ForMember(dest => dest.CustomStringField3State, opt => opt.MapFrom(src => src.CustomStringFields.CustomField3State))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CustomTextField1Name, opt => opt.MapFrom(src => src.CustomTextFields.CustomField1Name))
                .ForMember(dest => dest.CustomTextField1State, opt => opt.MapFrom(src => src.CustomTextFields.CustomField1State))
                .ForMember(dest => dest.CustomTextField2Name, opt => opt.MapFrom(src => src.CustomTextFields.CustomField2Name))
                .ForMember(dest => dest.CustomTextField2State, opt => opt.MapFrom(src => src.CustomTextFields.CustomField2State))
                .ForMember(dest => dest.CustomTextField3Name, opt => opt.MapFrom(src => src.CustomTextFields.CustomField3Name))
                .ForMember(dest => dest.CustomTextField3State, opt => opt.MapFrom(src => src.CustomTextFields.CustomField3State))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CustomIntField1Name, opt => opt.MapFrom(src => src.CustomIntegerFields.CustomField1Name))
                .ForMember(dest => dest.CustomIntField1State, opt => opt.MapFrom(src => src.CustomIntegerFields.CustomField1State))
                .ForMember(dest => dest.CustomIntField2Name, opt => opt.MapFrom(src => src.CustomIntegerFields.CustomField2Name))
                .ForMember(dest => dest.CustomIntField2State, opt => opt.MapFrom(src => src.CustomIntegerFields.CustomField2State))
                .ForMember(dest => dest.CustomIntField3Name, opt => opt.MapFrom(src => src.CustomIntegerFields.CustomField3Name))
                .ForMember(dest => dest.CustomIntField3State, opt => opt.MapFrom(src => src.CustomIntegerFields.CustomField3State));

            this.CreateMap<CategoryEntity, CollectionCategoryModel>().ReverseMap();

            this.CreateMap<ItemEntity, ItemModel>()
                .ForMember(dest => dest.CustomDateTimeFieldData, opt => opt.MapFrom(src => new CustomFieldForData<DateTime?>
                {
                    CustomField1Data = src.CustomDateTimeField1Data,
                    CustomField2Data = src.CustomDateTimeField2Data,
                    CustomField3Data = src.CustomDateTimeField3Data,
                }))
                .ForMember(dest => dest.CustomTextFieldData, opt => opt.MapFrom(src => new CustomFieldForData<string?>
                {
                    CustomField1Data = src.CustomTextField1Data,
                    CustomField2Data = src.CustomTextField2Data,
                    CustomField3Data = src.CustomTextField3Data,
                }))
                .ForMember(dest => dest.CustomIntFieldData, opt => opt.MapFrom(src => new CustomFieldForData<int?>
                {
                    CustomField1Data = src.CustomIntField1Data,
                    CustomField2Data = src.CustomIntField2Data,
                    CustomField3Data = src.CustomIntField3Data,
                }))
                .ForMember(dest => dest.CustomBoolFieldData, opt => opt.MapFrom(src => new CustomFieldForData<bool?>
                {
                    CustomField1Data = src.CustomBoolField1Data,
                    CustomField2Data = src.CustomBoolField2Data,
                    CustomField3Data = src.CustomBoolField3Data,
                }))
                .ForMember(dest => dest.CustomStringFieldData, opt => opt.MapFrom(src => new CustomFieldForData<string?>
                {
                    CustomField1Data = src.CustomStringField1Data,
                    CustomField2Data = src.CustomStringField2Data,
                    CustomField3Data = src.CustomStringField3Data,
                }));

            this.CreateMap<ItemModel, ItemEntity>()
                .ForMember(dest => dest.CustomBoolField1Data, opt => opt.MapFrom(src => src.CustomBoolFieldData.CustomField1Data))
                .ForMember(dest => dest.CustomBoolField2Data, opt => opt.MapFrom(src => src.CustomBoolFieldData.CustomField2Data))
                .ForMember(dest => dest.CustomBoolField3Data, opt => opt.MapFrom(src => src.CustomBoolFieldData.CustomField3Data))

                .ForMember(dest => dest.CustomDateTimeField1Data, opt => opt.MapFrom(src => src.CustomDateTimeFieldData.CustomField1Data))
                .ForMember(dest => dest.CustomDateTimeField2Data, opt => opt.MapFrom(src => src.CustomDateTimeFieldData.CustomField2Data))
                .ForMember(dest => dest.CustomDateTimeField3Data, opt => opt.MapFrom(src => src.CustomDateTimeFieldData.CustomField3Data))

                .ForMember(dest => dest.CustomIntField1Data, opt => opt.MapFrom(src => src.CustomIntFieldData.CustomField1Data))
                .ForMember(dest => dest.CustomIntField2Data, opt => opt.MapFrom(src => src.CustomIntFieldData.CustomField2Data))
                .ForMember(dest => dest.CustomIntField3Data, opt => opt.MapFrom(src => src.CustomIntFieldData.CustomField3Data))

                .ForMember(dest => dest.CustomStringField1Data, opt => opt.MapFrom(src => src.CustomStringFieldData.CustomField1Data))
                .ForMember(dest => dest.CustomStringField2Data, opt => opt.MapFrom(src => src.CustomStringFieldData.CustomField2Data))
                .ForMember(dest => dest.CustomStringField3Data, opt => opt.MapFrom(src => src.CustomStringFieldData.CustomField3Data))

                .ForMember(dest => dest.CustomTextField1Data, opt => opt.MapFrom(src => src.CustomTextFieldData.CustomField1Data))
                .ForMember(dest => dest.CustomTextField2Data, opt => opt.MapFrom(src => src.CustomTextFieldData.CustomField2Data))
                .ForMember(dest => dest.CustomTextField3Data, opt => opt.MapFrom(src => src.CustomTextFieldData.CustomField3Data));

            this.CreateMap<TagEntity, TagModel>()
                .ForMember(dest => dest.Item, opt => opt.Ignore())
                .ForMember(dest => dest.ItemId, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            this.CreateMap<TagModel, TagEntity>()
                .ForMember(dest => dest.ItemsTags, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

        private CustomFieldsModel MapCustomFieldsModel(bool stateOne, string nameOne, bool stateTwo, string nameTwo, bool stateThree, string nameThree)
        {
            return new CustomFieldsModel
            {
                CustomField1State = stateOne,
                CustomField1Name = nameOne,
                CustomField2State = stateTwo,
                CustomField2Name = nameTwo,
                CustomField3State = stateThree,
                CustomField3Name = nameThree
            };
        }
    }
}
