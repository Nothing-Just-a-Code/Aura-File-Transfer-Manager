![GitHub all releases](https://img.shields.io/github/downloads/Nothing-Just-a-Code/Aura-File-Transfer-Manager/total?style=for-the-badge)


# <img width="34" height="35" alt="Aura Icon Png" src="https://github.com/user-attachments/assets/95b2e590-e0a7-4b0c-b7a7-11e3a5b393b3" /> Aura File Transfer Manager

### Precision file mobility for demanding workflows.

Aura replaces the default Windows file copier with a robust, high‑integrity transfer engine wrapped in a polished, intuitive interface. It gives you full control over every operation—pause, resume, verify, skip errors, and resolve conflicts interactively—without compromising speed or reliability.
<img width="4000" height="2180" alt="Aura Main Logo" src="https://github.com/user-attachments/assets/246afcad-009e-436d-91a1-a78adbbbc771" />

---

## ✨ Key Features

### ⚡ High‑Performance Transfer Engine
- **Concurrent Processing** – Run up to 10 simultaneous file copies, dynamically balanced to keep your storage saturated without overloading the system.
- **Asynchronous I/O** – Non‑blocking read/write operations keep the interface responsive, even during massive transfers.
- **Background Verification** – Integrity checks run on a dedicated thread pool, allowing new copies to start while previous files are verified.

### 🛡️ Data Integrity & Verification
- **Quick Verification (xxHash3)** – Hardware‑accelerated, non‑cryptographic hashing with negligible performance impact.
- **Full Verification (SHA‑256)** – FIPS‑compliant cryptographic hash that mathematically guarantees copy fidelity.
- **Automatic Remediation** – Corrupted destination files are deleted immediately; progress is rolled back to reflect only verified data.

### 🔀 Intelligent Conflict Resolution
- **Auto‑Skip Identical Files** – Files with matching size and last‑modified time are silently skipped, saving time.
- **Interactive Dialog** – A custom prompt shows full source/destination metadata (path, size, date, checksum) for informed decisions.
- **Three‑Way Action** – Overwrite, Skip, or Rename the incoming file with one click.
- **Apply to All** – Propagate your choice to all subsequent conflicts within the same job.

### 🧵 Job Lifecycle Control
- **Independent Pause/Resume** – Pause any job individually without affecting others.
- **Cancellable Transfers** – Cancel on demand; partially‑written files are deleted and progress counters are rolled back.
- **Resume Interrupted Copies** – Pick up incomplete transfers from the exact byte offset, avoiding redundant work.

### 🔄 Error Recovery & Resilience
- **Configurable Retries** – Set the number of automatic retries and the delay between attempts.
- **Fault Isolation** – When one file fails, other files continue processing (unless you choose to stop the job on first error).
- **Transient Recovery** – Temporary I/O hiccups, anti‑virus locks, and device disconnections trigger automatic retries.

### 🗂️ Full Folder & File Handling
- **Recursive Directory Preservation** – The complete folder tree, including the source folder itself and all subdirectories, is recreated at the destination.
- **Mixed Source Support** – Select files, folders, or any combination; the engine enumerates all nested content automatically.
- **Free Space Pre‑Check** – Verifies sufficient destination space before the first byte is written; aborts cleanly if not.
- **Move Operations** – After successful copy and verification, source files are deleted, leaving no remnants.

### 🖥️ System‑Level Integration
- **Keyboard Interception** – A global listener detects `Ctrl+V` system‑wide and redirects paste operations to Aura, replacing the default Windows copier.
- **Copy/Move Detection** – Automatically distinguishes between a Copy (`Ctrl+C`) and a Cut (`Ctrl+X`) via the clipboard’s drop effect flag.
- **Context Menu Entry** – Add “Paste with Aura” to the right‑click menu of folder backgrounds and folder icons for instant access.

### 📊 Real‑Time Progress & Feedback
- **Dual‑Level Progress** – Track both per‑file (percentage, speed, ETA) and overall job progress simultaneously.
- **Instant Updates** – Progress refreshes on every I/O cycle with no artificial throttling, giving you live, granular feedback.
- **Visual File Tracking** – An icon‑based list displays every file with its current state: `Waiting` → `Transferring` → `Done` / `Failed` / `Skipped`.
- **Job‑Specific Windows** – Each transfer runs in its own modeless window with full progress details and dedicated pause/resume/cancel controls.

### ⚙️ Customisable Performance & Behavior
- **Buffer Size Presets** – Choose from six levels (64 KB to 16 MB) with clear descriptions and memory‑usage warnings.
- **Adjustable Parallelism** – Set the maximum number of simultaneous file copies (1–10) to match your hardware.
- **Global Defaults** – Configure preferred overwrite mode, verification level, retry count, retry delay, and more; override per‑job as needed.
- **Resume Partial Files** – Optionally skip already‑transferred data when resuming an interrupted copy.

### 🧰 Diagnostics & Maintenance
- **Structured Logging** – All engine events (job start, file completion, errors, cancellations) are recorded with timestamps and contextual data.
- **Rolling Log Files** – Daily logs with automatic retention ensure traceability without manual cleanup.

---

## 🚀 Quick Start

1. **Download** the latest installer from the [Releases](../../releases) page.
2. **Install** with the provided setup wizard.
3. **Copy** files as usual (`Ctrl+C` or right‑click → Copy).
4. **Paste** anywhere (`Ctrl+V` or right‑click → Paste with Aura) – the transfer is handled automatically by Aura.
5. **Monitor** progress in the job window that opens; pause, resume, or cancel at any time.

---

## 📸 Screenshots

<img width="799" height="473" alt="aura main" src="https://github.com/user-attachments/assets/6f177327-f4aa-4d4f-ba2f-278f1ec3c965" />

<img width="495" height="231" alt="aura transfer job" src="https://github.com/user-attachments/assets/8713e337-34dd-4dba-a8d8-80b3a3fb864b" />

<img width="836" height="525" alt="aura settings" src="https://github.com/user-attachments/assets/f3e159f6-af8a-42f6-a498-b12dc5aec52e" />


---

## 📜 License

This project is licensed under a custom open‑source license.  
You are free to use the software at no charge. Modified versions must credit **NJAC**, and selling copies of the software is strictly prohibited.  
See the [LICENSE](LICENSE) file for the full text.

---

## 🌟 Why Aura?

Aura gives you enterprise‑grade file transfer capabilities without paywalls, bloat, or compromise. It’s built for professionals who demand absolute reliability and control—whether you’re moving terabytes of media, synchronising directory trees, or managing archival data.

---

*© 2026 NJAC. All rights reserved.*
---
