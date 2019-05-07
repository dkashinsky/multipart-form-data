export interface UserModel {
  name: string;
  date: string;
  avatar: File;
  cv: File;
}

export function toFormData(userModel: UserModel): FormData {
  const formData = new FormData();

  if (userModel.name) {
    formData.append('name', userModel.name);
  }

  if (userModel.date) {
    formData.append('date', userModel.date);
  }

  if (userModel.avatar) {
    formData.append('avatarFile', userModel.avatar, userModel.avatar.name);
  }

  if (userModel.cv) {
    formData.append('cvFile', userModel.cv, userModel.cv.name);
  }

  return formData;
}
