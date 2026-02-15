ARG USER_UID=1001
ARG USER_GID=$USER_UID
FROM mcr.microsoft.com/dotnet/sdk:10.0

# Include .NET SDK 8.0
COPY --from=mcr.microsoft.com/dotnet/sdk:8.0 /usr/share/dotnet/shared /usr/share/dotnet/shared

WORKDIR /TheCleanArch

ARG USER_UID
ARG USER_GID
RUN \
    groupadd --gid ${USER_GID} tcadev && \
    useradd --uid ${USER_UID} --gid ${USER_GID} -m tcadev && \
    apt update && apt full-upgrade -y && \
    apt install sudo git ssh -y && \
    echo tcadev ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/tcadev && \
    chmod 0440 /etc/sudoers.d/tcadev 

USER tcadev