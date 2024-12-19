# Minilemon Explorer
Repository ini berisikan project files yang digunakan dalam pembuatan Minilemon Explorer

## Prerequisites
- Unity 2022.3.42f1
- Code Editor (Misal Visual Studio atau VSCode)

## First Steps
1. Fork repository ini terlebih dahulu dengan menekan tombol **Fork** di atas.
2. Buka terminal atau command prompt.
3. Lakukan cloning dengan perintah `git clone` diikuti dengan URL fork anda
    > Link repository bisa dilihat dengan menekan tombol **Code** berwarna hijau di halaman repository fork anda, dan 
4. Buka **Unity Hub**, Tekan **Add > Add project from disk**, lalu pilih folder repository anda\
(secara default nama folder sesuai dengan nama repository)

## Stay Up-to-Date
1. Tambahkan remote repository utama untuk memastikan fork anda sinkron dengan repository utama:
    ```sh
    git remote add upstream https://github.com/Minilemon-Games/Minilemon-Games.git
    ```
2. Untuk memastikan fork anda selalu up-to-date dengan repository utama, jalankan perintah berikut secara berkala:
    ```sh
    git fetch upstream
    git checkout main
    git merge upstream/main
    ```
    Atau bisa dengan menekan tombol **Sync fork** di Github anda, lalu melakukan fetch/pull di device anda.