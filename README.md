# Minilemon Explorer
Repository ini berisikan project files yang digunakan dalam pembuatan game Minilemon Explorer.

## Prerequisites
- Unity 2022.3.42f1
- Code Editor (misal Visual Studio atau VSCode)

## First Steps
1. Fork repository ini terlebih dahulu dengan menekan tombol **Fork** di atas.
2. Buka terminal atau command prompt.
3. Lakukan cloning dengan perintah berikut:
    ```sh
    # Contoh
    git clone https://github.com/<username-anda>/Minilemon-Games.git
    ```
    > Link repository anda bisa dilihat dengan menekan tombol **Code** berwarna hijau di halaman fork anda, dan mengcopy URL HTTPS yang sudah disediakan.
4. Buka **Unity Hub**, Tekan **Add > Add project from disk**, lalu pilih folder repository anda.
    > Secara default nama folder sesuai dengan nama repository.
> [!NOTE]
> Dikarenakan ukuran repository yang cukup besar, disarankan untuk melakukan clone dengan jaringan internet yang memadai.

## Stay Up-to-Date
1. Tambahkan remote repository utama untuk memastikan fork anda sinkron dengan repository utama:
    ```sh
    git remote add upstream https://github.com/Minilemon-Games/Minilemon-Games.git
    ```
2. Untuk memastikan fork anda selalu up-to-date dengan repository utama, jalankan perintah berikut secara berkala:
    ```sh
    git fetch upstream
    git checkout main
    git rebase upstream/main
    git push origin main
    ```
> [!NOTE]
> Cara lainnya adalah dengan menekan tombol **Sync fork** di Github anda, lalu melakukan fetch/pull di device anda

## Good Practices
1. Jika ingin menambahkan satu fitur/melakukan pengubahan file, **lakukan di branch baru**
> [!IMPORTANT]
> Branch `main` digunakan untuk syncing dengan repository utama
2. Jika ingin menambah file dan/atau memindahkan file, pastikan Unity Engine dalam keadaan **terbuka** dan lakukan cut/copy/paste **di dalam Unity Engine**
> [!CAUTION]
> Memindahkan file di luar Unity Engine dapat mengakibatkan **Meta file conflict**, yaitu ketika beberapa kontributor memiliki file yang sama tetapi dengan pointer (meta) yang berbeda-beda.\
> \
> Hal tersebut disebabkan oleh pemindahan file asset yang tidak diikuti dengan pemindahan file meta.


## Project Structure